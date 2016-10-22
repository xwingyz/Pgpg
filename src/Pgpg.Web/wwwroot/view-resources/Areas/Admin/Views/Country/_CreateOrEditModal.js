(function () {
    app.modals.CreateOrEditCountryModal = function () {

        var _modalManager;
        var _countryService = abp.services.app.country;
        var _$countryInformationForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;


            _$countryInformationForm = _modalManager.getModal().find('form[name=CountryInformationsForm]');
            _$countryInformationForm.validate({ ignore: "" });
        };

        this.save = function () {
            if (!_$countryInformationForm.valid()) {
                return;
            }

            var country = _$countryInformationForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _countryService.createOrUpdateCountry({
                country: country
            }).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditCountryModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})();