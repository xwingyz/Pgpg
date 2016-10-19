var app = app || {};
(function ($) {

    app.UserNotificationHelper = (function () {

        return function () {

            /* Message Extracting based on Notification Data Type ********/

            //add your custom notification data types here...

            /* Example:
            abp.notifications.messageFormatters['Pgpg.MyNotificationDataType'] = function(userNotification) {
                return ...; //format and return message here
            };
            */

            var _notificationService = abp.services.app.notification;

            /* Converter functions ***************************************/

            function getUrl(userNotification) {
                switch (userNotification.notification.notificationName) {
                    case 'App.NewUserRegistered':
                        return '/Admin/users?filterText=' + userNotification.notification.data.properties.emailAddress;
                    case 'App.NewTenantRegistered':
                        return '/Admin/tenants?filterText=' + userNotification.notification.data.properties.tenancyName;
                        //Add your custom notification names to navigate to a URL when user clicks to a notification.
                }

                //No url for this notification
                return null;
            };

            /* PUBLIC functions ******************************************/

            var format = function (userNotification, truncateText) {
                var formatted = {
                    userNotificationId: userNotification.id,
                    text: abp.notifications.getFormattedMessageFromUserNotification(userNotification),
                    time: moment(userNotification.notification.creationTime).format("YYYY-MM-DD HH:mm:ss"),
                    icon: app.notification.getUiIconBySeverity(userNotification.notification.severity),
                    state: abp.notifications.getUserNotificationStateAsString(userNotification.state),
                    data: userNotification.notification.data,
                    url: getUrl(userNotification),
                    isUnread: userNotification.state === abp.notifications.userNotificationState.UNREAD,
                    timeAgo: moment(userNotification.notification.creationTime).fromNow()
                };

                if (truncateText || truncateText === undefined) {
                    formatted.text = abp.utils.truncateStringWithPostfix(formatted.text, 100);
                }
                
                return formatted;
            };

            var show = function (userNotification) {
                abp.notifications.showUiNotifyForUserNotification(userNotification, {
                    'onclick': function () {
                        //Take action when user clicks to live toastr notification
                        var url = getUrl(userNotification);
                        if (url) {
                            location.href = url;
                        }
                    }
                });
            };

            var setAllAsRead = function (callback) {
                _notificationService.setAllNotificationsAsRead().done(function () {
                    abp.event.trigger('app.notifications.refresh');
                    callback && callback();
                });
            };

            var setAsRead = function (userNotificationId, callback) {
                _notificationService.setNotificationAsRead({
                    id: userNotificationId
                }).done(function () {
                    abp.event.trigger('app.notifications.read', userNotificationId);
                    callback && callback(userNotificationId);
                });
            };

            var openSettingsModal = function () {
                new app.ModalManager({
                    viewUrl: abp.appPath + 'Admin/Notifications/SettingsModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/Admin/Views/Notifications/_SettingsModal.js',
                    modalClass: 'NotificationSettingsModal'
                }).open();
            };

            /* Expose public API *****************************************/

            return {
                format: format,
                show: show,
                setAllAsRead: setAllAsRead,
                setAsRead: setAsRead,
                openSettingsModal: openSettingsModal
            };

        };

    })();

})(jQuery);
var app = app || {};
(function () {

    $.extend(app, {
        consts: {
            grid: {
                defaultPageSize: 10,
                defaultPageSizes: [10, 20, 50, 100]
            },
            userManagement: {
                defaultAdminUserName: 'admin'
            },
            contentTypes: {
                formUrlencoded: 'application/x-www-form-urlencoded; charset=UTF-8'
            },
            friendshipState: {
                accepted: 1,
                blocked: 2
            }
        }
    });

})();
var app = app || {};
(function () {

    var appLocalizationSource = abp.localization.getSource('Pgpg');
    app.localize = function () {
        return appLocalizationSource.apply(this, arguments);
    };

    app.downloadTempFile = function (file) {
        location.href = abp.appPath + 'File/DownloadTempFile?fileType=' + file.fileType + '&fileToken=' + file.fileToken + '&fileName=' + file.fileName;
    };

    app.createDateRangePickerOptions = function () {
        var options = {
            locale: {
                format: 'L',
                applyLabel: app.localize('Apply'),
                cancelLabel: app.localize('Cancel'),
                customRangeLabel: app.localize('CustomRange')
            },
            min: moment('2015-05-01'),
            minDate: moment('2015-05-01'),
            max: moment(),
            maxDate: moment(),
            ranges: {}
        };

        options.ranges[app.localize('Today')] = [moment().startOf('day'), moment().endOf('day')];
        options.ranges[app.localize('Yesterday')] = [moment().subtract(1, 'days').startOf('day'), moment().subtract(1, 'days').endOf('day')];
        options.ranges[app.localize('Last7Days')] = [moment().subtract(6, 'days').startOf('day'), moment().endOf('day')];
        options.ranges[app.localize('Last30Days')] = [moment().subtract(29, 'days').startOf('day'), moment().endOf('day')];
        options.ranges[app.localize('ThisMonth')] = [moment().startOf('month'), moment().endOf('month')];
        options.ranges[app.localize('LastMonth')] = [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')];

        return options;
    };

    app.getUserProfilePicturePath = function (profilePictureId) {
        return profilePictureId ?
                            (abp.appPath + 'Profile/GetProfilePictureById?id=' + profilePictureId) :
                            (abp.appPath + 'Common/Images/default-profile-picture.png');
    }

    app.getUserProfilePicturePath = function () {
        return abp.appPath + 'Profile/GetProfilePicture?v=' + new Date().valueOf();
    }

    app.getShownLinkedUserName = function (linkedUser) {
        if (!abp.multiTenancy.isEnabled) {
            return linkedUser.userName;
        } else {
            if (linkedUser.tenancyName) {
                return linkedUser.tenancyName + '\\' + linkedUser.username;
            } else {
                return '.\\' + linkedUser.username;
            }
        }
    }

    app.notification = app.notification || {};

    app.notification.getUiIconBySeverity = function (severity) {
        switch (severity) {
            case abp.notifications.severity.SUCCESS:
                return 'fa fa-check';
            case abp.notifications.severity.WARN:
                return 'fa fa-warning';
            case abp.notifications.severity.ERROR:
                return 'fa fa-bolt';
            case abp.notifications.severity.FATAL:
                return 'fa fa-bomb';
            case abp.notifications.severity.INFO:
            default:
                return 'fa fa-info';
        }
    };

    app.changeNotifyPosition = function(positionClass) {
        if (!toastr) {
            return;
        }

        toastr.clear();
        toastr.options.positionClass = positionClass;
    };

    app.waitUntilElementIsReady = function (selector, callback, checkPeriod) {
        if (!$) {
            return;
        }

        var elementCount = selector.split(',').length;

        if (!checkPeriod) {
            checkPeriod = 100;
        }

        var checkExist = setInterval(function () {
            if ($(selector).length >= elementCount) {
                clearInterval(checkExist);
                callback();
            }
        }, checkPeriod);
    };

    app.calculateTimeDifference = function (fromTime, toTime, period) {
        if (!moment) {
            return null;
        }

        var from = moment(fromTime);
        var to = moment(toTime);
        return to.diff(from, period);
    }

})();
/* Here, there are some custom plug-ins.
 * Developed for ASP.NET Iteration Zero (http://aspnetzero.com). */
(function ($) {
    if (!$) {
        return;
    }

    /* A simple jQuery plug-in to make a button busy. */
    $.fn.buttonBusy = function (isBusy) {
        return $(this).each(function () {
            var $button = $(this);
            var $icon = $button.find('i');
            var $buttonInnerSpan = $button.find('span');

            if (isBusy) {
                if ($button.hasClass('button-busy')) {
                    return;
                }

                $button.attr('disabled', 'disabled');

                //change icon
                if ($icon.length) {
                    $button.data('iconOriginalClasses', $icon.attr('class'));
                    $icon.removeClass();
                    $icon.addClass('fa fa-spin fa-spinner');
                }

                //change text
                if ($buttonInnerSpan.length && $button.attr('busy-text')) {
                    $button.data('buttonOriginalText', $buttonInnerSpan.html());
                    $buttonInnerSpan.html($button.attr('busy-text'));
                }

                $button.addClass('button-busy');
            } else {
                if (!$button.hasClass('button-busy')) {
                    return;
                }
                
                //enable button
                $button.removeAttr('disabled');

                //restore icon
                if ($icon.length && $button.data('iconOriginalClasses')) {
                    $icon.removeClass();
                    $icon.addClass($button.data('iconOriginalClasses'));
                }

                //restore text
                if ($buttonInnerSpan.length && $button.data('buttonOriginalText')) {
                    $buttonInnerSpan.html($button.data('buttonOriginalText'));
                }

                $button.removeClass('button-busy');
            }
        });
    };

    $.fn.serializeFormToObject = function() {
        //serialize to array
        var data = $(this).serializeArray();

        //add also disabled items
        $(':disabled[name]', this)
            .each(function() {
                data.push({ name: this.name, value: $(this).val() });
            });

        //map to object
        var obj = {};
        data.map(function(x) { obj[x.name] = x.value; });

        return obj;
    };

})(jQuery);
(function () {

    //Set Moment Timezone
    if (abp.clock.provider.supportsMultipleTimezone && window.moment) {
        moment.tz.setDefault(abp.timing.timeZoneInfo.iana.timeZoneId);
    }

    //Localize Sweet Alert
    if (abp.libs.sweetAlert) {
        abp.libs.sweetAlert.config.info.confirmButtonText = app.localize("Ok");
        abp.libs.sweetAlert.config.success.confirmButtonText = app.localize("Ok");
        abp.libs.sweetAlert.config.warn.confirmButtonText = app.localize("Ok");
        abp.libs.sweetAlert.config.error.confirmButtonText = app.localize("Ok");

        abp.libs.sweetAlert.config.confirm.confirmButtonText = app.localize("Yes");
        abp.libs.sweetAlert.config.confirm.cancelButtonText = app.localize("Cancel");
    }

})();
var app = app || {};
(function ($) {

    var _loadedScripts = [];

    app.modals = app.modals || {};

    app.ModalManager = (function () {

        var _normalizeOptions = function (options) {
            if (!options.modalId) {
                options.modalId = 'Modal_' + (Math.floor((Math.random() * 1000000))) + new Date().getTime();
            }
        }

        function _removeContainer(modalId) {
            var _containerId = modalId + 'Container';
            var _containerSelector = '#' + _containerId;

            var $container = $(_containerSelector);
            if ($container.length) {
                $container.remove();
            }
        };

        function _createContainer(modalId) {
            _removeContainer(modalId);

            var _containerId = modalId + 'Container';
            return $('<div id="' + _containerId + '"></div>')
                .append(
                    '<div id="' + modalId + '" class="modal fade" tabindex="-1" role="modal" aria-hidden="true">' +
                    '  <div class="modal-dialog">' +
                    '    <div class="modal-content"></div>' +
                    '  </div>' +
                    '</div>'
                ).appendTo('body');
        }

        return function (options) {

            _normalizeOptions(options);

            var _options = options;
            var _$modal = null;
            var _modalId = options.modalId;
            var _modalSelector = '#' + _modalId;
            var _modalObject = null;

            var _publicApi = null;
            var _args = null;
            var _getResultCallback = null;

            var _onCloseCallbacks = [];

            function _saveModal() {
                if (_modalObject && _modalObject.save) {
                    _modalObject.save();
                }
            }

            function _initAndShowModal() {
                _$modal = $(_modalSelector);

                _$modal.modal({
                    backdrop: 'static'
                });

                _$modal.on('hidden.bs.modal', function () {
                    _removeContainer(_modalId);

                    for (var i = 0; i < _onCloseCallbacks.length; i++) {
                        _onCloseCallbacks[i]();
                    }
                });

                _$modal.on('shown.bs.modal', function () {
                    _$modal.find('input:not([type=hidden]):first').focus();
                });

                var modalClass = app.modals[options.modalClass];
                if (modalClass) {
                    _modalObject = new modalClass();
                    if (_modalObject.init) {
                        _modalObject.init(_publicApi, _args);
                    }
                }

                _$modal.find('.save-button').click(function () {
                    _saveModal();
                });

                _$modal.find('.modal-body').keydown(function (e) {
                    if (e.which == 13) {
                        e.preventDefault();
                        _saveModal();
                    }
                });

                _$modal.modal('show');
            };

            var _open = function (args, getResultCallback) {

                _args = args || {};
                _getResultCallback = getResultCallback;

                _createContainer(_modalId)
                    .find('.modal-content')
                    .load(options.viewUrl, _args, function (response, status, xhr) {
                        if (status == "error") {
                            abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                            return;
                        };

                        if (options.scriptUrl && _.indexOf(_loadedScripts, options.scriptUrl) < 0) {
                            $.getScript(options.scriptUrl)
                                .done(function (script, textStatus) {
                                    _loadedScripts.push(options.scriptUrl);
                                    _initAndShowModal();
                                })
                                .fail(function (jqxhr, settings, exception) {
                                    abp.message.warn(abp.localization.abpWeb('InternalServerError'));
                                });
                        } else {
                            _initAndShowModal();
                        }
                    });
            };

            var _close = function() {
                if (!_$modal) {
                    return;
                }

                _$modal.modal('hide');
            };

            var _onClose = function (onCloseCallback) {
                _onCloseCallbacks.push(onCloseCallback);
            }

            function _setBusy(isBusy) {
                if (!_$modal) {
                    return;
                }

                _$modal.find('.modal-footer button').buttonBusy(isBusy);
            }

            _publicApi = {

                open: _open,

                reopen: function() {
                    _open(_args);
                },

                close: _close,

                getModalId: function () {
                    return _modalId;
                },

                getModal: function () {
                    return _$modal;
                },

                getArgs: function () {
                    return _args;
                },

                getOptions: function() {
                    return _options;
                },

                setBusy: _setBusy,

                setResult: function() {
                    _getResultCallback && _getResultCallback.apply(_publicApi, arguments);
                },

                onClose: _onClose
            }

            return _publicApi;

        };
    })();

})(jQuery);
(function () {
    app.PasswordComplexityHelper = function () {

        function reviver(key, val) {
            if (key && key.charAt(0) !== key.charAt(0).toLowerCase())
                this[key.charAt(0).toLowerCase() + key.slice(1)] = val;
            else
                return val;
        };

        var _buildPasswordComplexityErrorMessage = function (setting) {
            var message = "<ul>";

            if (setting.minLength) {
                message += "<li>" + abp.utils.formatString(app.localize("PasswordComplexity_MinLength_Hint"), setting.minLength) + "</li>";
            }

            if (setting.maxLength) {
                message += "<li>" + abp.utils.formatString(app.localize("PasswordComplexity_MaxLength_Hint"), setting.maxLength) + "</li>";
            }

            if (setting.useUpperCaseLetters) {
                message += "<li>" + app.localize("PasswordComplexity_UseUpperCaseLetters_Hint") + "</li>";
            }

            if (setting.useLowerCaseLetters) {
                message += "<li>" + app.localize("PasswordComplexity_UseLowerCaseLetters_Hint") + "</li>";
            }

            if (setting.useNumbers) {
                message += "<li>" + app.localize("PasswordComplexity_UseNumbers_Hint") + "</li>";
            }

            if (setting.usePunctuations) {
                message += "<li>" + app.localize("PasswordComplexity_UsePunctuations_Hint") + "</li>";
            }

            return message + "</ul>";
        }

        var _setPasswordComplexityRules = function ($element, setting) {
            
            setting = JSON.parse(JSON.stringify(setting), reviver);

            if (setting) {
                var message = _buildPasswordComplexityErrorMessage(setting);
                
                jQuery.validator.addMethod("passwordComplexity", function (value, element) {
                    if (value.length < setting.minLength) {
                        return false;
                    }

                    if (value.length > setting.maxLength) {
                        return false;
                    }

                    if (setting.useUpperCaseLetters && !/[A-Z]/.test(value)) {
                        return false;
                    }

                    if (setting.useUpperCaseLetters && !/[a-z]/.test(value)) {
                        return false;
                    }

                    if (setting.useNumbers && !/[0-9]/.test(value)) {
                        return false;
                    }

                    if (setting.usePunctuations && !/[!@#\$%\^\&*'"\/{}\[\]?,;|)\(+=._-]+/.test(value)) {
                        return false;
                    }

                    return true;
                }, message);

                $element.rules("add", "passwordComplexity");
            }
        };

        return {
            setPasswordComplexityRules: _setPasswordComplexityRules
        };
    };
})();
var app = app || {};
(function () {

    app.utils = app.utils || {};

    app.utils.truncateString = function(str, maxLength, postfix) {
        if (!str || !maxLength || str.length <= maxLength) {
            return str;
        }

        if (postfix === false) {
            return str.substr(0, maxLength);
        }

        return str.substr(0, maxLength - 1) + '&#133;';
    }

})();
/* An empty javascript file.
 * Used in ScriptPaths.JQuery_Validation_Localization.*/
var app = app || {};
(function () {

    app.chat = app.chat || {};
    app.chat.side = {
        sender: 1,
        receiver: 2
    };

    app.chat.readState = {
        unread: 1,
        read: 2
    };

    app.chat.sendMessage = function () {
        console.log(arguments);
    };

})();

var app = app || {};
(function ($) {

    //Check if SignalR is defined
    if (!$ || !$.connection) {
        return;
    }

    //Create namespaces
    app.signalr = app.signalr || {};
    app.signalr.hubs = app.signalr.hubs || {};

    //Get the chat hub
    app.signalr.hubs.chat = app.signalr.hubs.chat || $.connection.chatHub;

    var chatHub = app.signalr.hubs.chat;
    if (!chatHub) {
        return;
    }

    $.connection.hub.stateChanged(function (data) {
        if (data.newState === $.connection.connectionState.connected) {
            abp.event.trigger('app.chat.connected');
        }
    });

    chatHub.client.getChatMessage = function (message) {
        abp.event.trigger('app.chat.messageReceived', message);
    };

    chatHub.client.getAllFriends = function (friends) {
        abp.event.trigger('abp.chat.friendListChanged', friends);
    };

    chatHub.client.getFriendshipRequest = function (friendData, isOwnRequest) {
        abp.event.trigger('app.chat.friendshipRequestReceived', friendData, isOwnRequest);
    };

    chatHub.client.getUserConnectNotification = function (friend, isConnected) {
        abp.event.trigger('app.chat.userConnectionStateChanged',
        {
            friend: friend,
            isConnected: isConnected
        });
    };

    chatHub.client.getUserStateChange = function (friend, state) {
        abp.event.trigger('app.chat.userStateChanged',
        {
            friend: friend,
            state: state
        });
    };

    chatHub.client.getallUnreadMessagesOfUserRead = function (friend) {
        abp.event.trigger('app.chat.allUnreadMessagesOfUserRead',
        {
            friend: friend
        });
    };

    app.chat.sendMessage = function (messageData, callback) {
        if ($.connection.hub.state !== $.signalR.connectionState.connected) {
            callback && callback();
            abp.notify.warn(app.localize('ChatIsNotConnectedWarning'));
            return;
        }

        chatHub.server.sendMessage(messageData).done(function (result) {
            if (result) {
                abp.notify.warn(result);
            }

        }).always(function () {
            callback && callback();
        });
    };

})(jQuery);
var app = app || {};
(function () {

    app.localStorage = app.localStorage || {};

    app.localStorage.setItem = function (key, value) {
        if (!localStorage) {
            return;
        }

        localStorage.setItem(key, JSON.stringify(value));
    };

    app.localStorage.getItem = function (key, callback) {
        if (!localStorage) {
            return null;
        }

        var value = localStorage.getItem(key);
        if (callback) {
            callback(value);
        } else {
            return value;
        }
    };

})();

var app = app || {};
(function () {

    app.localStorage = app.localStorage || {};

    app.localStorage.setItem = function (key, value) {
        if (!localforage) {
            return;
        }

        localforage.setItem(key, value);
    };

    app.localStorage.getItem = function (key, callback) {
        if (!localforage || !callback) {
            return;
        }

        localforage.getItem(key)
            .then(function (value) {
                callback(value);
            });
    };

})();