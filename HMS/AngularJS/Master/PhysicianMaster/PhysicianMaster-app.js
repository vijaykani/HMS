var physicianApp = angular.module('physicianApp', ['datatables', 'commonApp']);

physicianApp.service('physicianServices', function () {

    this.physicianData = function (physicianmaster) {
        debugger;
        this.PHYID = physicianmaster ? physicianmaster.PHYID : null;
        this.DOCTORNAME = physicianmaster ? physicianmaster.DOCTORNAME : null;
        this.SPECIALITY = physicianmaster ? physicianmaster.SPECIALITY : null;
        this.MOBILENO = physicianmaster ? physicianmaster.MOBILENO : null;
        this.ADDRESS_DETAIL = physicianmaster ? physicianmaster.ADDRESS_DETAIL : null;
        this.ORGID = physicianmaster ? physicianmaster.ORGID : null;
        this.INSERTBY = physicianmaster ? physicianmaster.INSERTBY : null;
        this.INSERTDATE = physicianmaster ? physicianmaster.INSERTDATE : null;
        this.MODIFYDATE = physicianmaster ? physicianmaster.MODIFYDATE : null;
        this.email_address = physicianmaster ? physicianmaster.email_address : null;
        this.U_ID = physicianmaster ? physicianmaster.U_ID : null;
        this.state = physicianmaster ? physicianmaster.state : null;
        this.city = physicianmaster ? physicianmaster.city : null;
        this.zipcode = physicianmaster ? physicianmaster.zipcode : null;
        this.ISACTIVE = physicianmaster ? physicianmaster.ISACTIVE : null;
        this.KEY = physicianmaster ? physicianmaster.KEY : null;

    };

    this.Savephysicianmaster = function (data) {
        debugger;
        this.url = "Master/Savephysicianmaster";
        this.param = JSON.stringify(data);
    };
    this.BindCity = function (data) {
        this.url = "Master/BindCity";
        this.param = JSON.stringify(data);
    };

});
