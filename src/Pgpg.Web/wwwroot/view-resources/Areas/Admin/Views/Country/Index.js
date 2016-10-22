(function () {
    $(function () {

        var _$countriesTable = $('#CountriesTable');
        var _countryService = abp.services.app.country;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Countries.Create'),
            edit: abp.auth.hasPermission('Pages.Countries.Edit'),
            'delete': abp.auth.hasPermission('Pages.Countries.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/Country/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/Admin/Views/Country/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditCountryModal'
        });

        _$countriesTable.jtable({

            title: app.localize('Countries'),

            actions: {
                listAction: {
                    method: _countryService.getCountries
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: app.localize('Actions'),
                    width: '25%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        if (_permissions.edit) {
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    _createOrEditModal.open({ id: data.record.id });
                                });
                        }

                        if (_permissions.delete) {
                            $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>')
                                .appendTo($span)
                                .click(function () {
                                    deleteCountry(data.record);
                                });
                        }

                        return $span;
                    }
                },
                name: {
                    title: app.localize('CountryName'),
                    width: '25%'
                },
                code: {
                    title: app.localize('CountryCode'),
                    width: '25%'
                },
                isActive: {
                    title: app.localize('Active'),
                    width: '25%',
                    display: function (data) {
                        if (data.record.isActive) {
                            return '<span class="label label-success">' + app.localize('Yes') + '</span>';
                        } else {
                            return '<span class="label label-default">' + app.localize('No') + '</span>';
                        }
                    }
                }
            }

        });

        function deleteCountry(country) {
            abp.message.confirm(
                app.localize('CountryDeleteWarningMessage', country.name),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _countryService.deleteCountry({
                            id: country.id
                        }).done(function () {
                            getCountries();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewCountryButton').click(function () {
            _createOrEditModal.open();
        });

        $('#RefreshCountriesButton').click(function (e) {
            e.preventDefault();
            getCountries();
        });

        function getCountries() {
            _$countriesTable.jtable('load', {});
        }

        abp.event.on('app.createOrEditCountryModalSaved', function () {
            getCountries();
        });

        getCountries();
    });
})();