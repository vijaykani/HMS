var drugmstApp = angular.module('drugmstApp', ['datatables', 'commonApp']);

drugmstApp.service('drugServices', function () {

    this.drugmstData = function (drugmaster) {
        debugger;
        this.DrugID = drugmaster ? drugmaster.DrugID : null;
        this.DrugName = drugmaster ? drugmaster.DrugName : null;
        this.OrgID = drugmaster ? drugmaster.OrgID : null;
        this.DrugType = drugmaster ? drugmaster.DrugType : null;
        this.CreatedBy = drugmaster ? drugmaster.CreatedBy : null;
        this.CreatedAt = drugmaster ? drugmaster.CreatedAt : null;
        this.ModifyBy = drugmaster ? drugmaster.ModifyBy : null;
        this.ModiyDate = drugmaster ? drugmaster.ModiyDate : null;
        this.ISACTIVE = drugmaster ? drugmaster.ISACTIVE : null;
        this.KEY = drugmaster ? drugmaster.KEY : null;

    };

    this.Savedrugmaster = function (data) {
        debugger;
        this.url = "Master/Savedrugmaster";
        this.param = JSON.stringify(data);
    };

});
