var investigationmstApp = angular.module('investigationmstApp', ['datatables', 'commonApp']);

investigationmstApp.service('investigationServices', function () {

    this.investigationmstData = function (investigationmaster) {
        debugger;
        this.InvesticationID = investigationmaster ? investigationmaster.InvesticationID : null;
        this.InvName = investigationmaster ? investigationmaster.InvName : null;
        this.InvCode = investigationmaster ? investigationmaster.InvCode : null;
        this.InvType = investigationmaster ? investigationmaster.InvType : null;
        this.Orgid = investigationmaster ? investigationmaster.Orgid : null;
        this.CreatedBy = investigationmaster ? investigationmaster.CreatedBy : null;
        this.CreatedAt = investigationmaster ? investigationmaster.CreatedAt : null;
        this.ModifyBy = investigationmaster ? investigationmaster.ModifyBy : null;
        this.ModiyDate = investigationmaster ? investigationmaster.ModiyDate : null;
        this.ISACTIVE = investigationmaster ? investigationmaster.ISACTIVE : null;
        this.KEY = investigationmaster ? investigationmaster.KEY : null;

    };

    this.Saveinvestigationmaster = function (data) {
        debugger;
        this.url = "Master/Saveinvestigationmaster";
        this.param = JSON.stringify(data);
    };

});
