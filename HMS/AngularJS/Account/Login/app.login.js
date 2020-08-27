var actionApp = angular.module('loginApp', ['commonApp', 'datatables']);

actionApp.service('actionServices', function () {
    this.SaveActionMaster = function (data) {
        this.url = "Administration/SaveActionMaster";
        this.param = JSON.stringify(data);
    };

});


