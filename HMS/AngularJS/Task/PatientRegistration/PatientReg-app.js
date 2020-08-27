var patientregApp = angular.module('patientregApp', ['datatables', 'commonApp']);

patientregApp.service('patientregServices', function () {

    this.patientregData = function (patientreg) {
        debugger;
        this.Patient_Id = patientreg ? patientreg.Patient_Id : null;
        this.Patient_no = patientreg ? patientreg.Patient_no : null;
        this.Title_id = patientreg ? patientreg.Title_id : null;
        this.Age = patientreg ? patientreg.Age : null;
        this.critical_info = patientreg ? patientreg.Patient_Id : null;
        this.Referred_by = patientreg ? patientreg.Patient_Id : null;
        this.Email = patientreg ? patientreg.Email : null;
        this.FirstName = patientreg ? patientreg.FirstName : null;
        this.FullName = patientreg ? patientreg.FullName : null;
        this.Lastname = patientreg ? patientreg.Lastname : null;
        this.Gender = patientreg ? patientreg.Gender : null;
        this.DOB = patientreg ? patientreg.DOB : null;
        this.Occupation = patientreg ? patientreg.Occupation : null;
        this.Blood_Group = patientreg ? patientreg.Blood_Group : null;
        this.Marital_Status = patientreg ? patientreg.Marital_Status : null;
        this.Home_address = patientreg ? patientreg.Home_address : null;
        this.Current_address = patientreg ? patientreg.Current_address : null;
        this.ISACTIVE = patientreg ? patientreg.ISACTIVE : null;
        this.country = patientreg ? patientreg.country : null;
        this.state = patientreg ? patientreg.state : null;
        this.City = patientreg ? patientreg.City : null;
        this.Mobileno = patientreg ? patientreg.Mobileno : null;
        this.Ethnicity = patientreg ? patientreg.Ethnicity : null;
        this.Org_id = patientreg ? patientreg.Org_id : null;
        this.Insertby = patientreg ? patientreg.Insertby : null;
        this.Insert_Date = patientreg ? patientreg.Insert_Date : null;
        this.Modify_date = patientreg ? patientreg.Modify_date : null;
        this.KEY = patientreg ? patientreg.KEY : null;

    };

    this.Savepatientreg = function (data) {
        debugger;
        this.url = "Task/Savepatientreg";
        this.param = JSON.stringify(data);
    };
    this.BindCity = function (data) {
        debugger;
        this.url = "Task/BindCity";
        this.param = JSON.stringify(data);
    };

});
