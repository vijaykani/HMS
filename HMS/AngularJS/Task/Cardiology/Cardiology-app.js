var cardiologyApp = angular.module('cardiologyApp', ['datatables', 'commonApp']);

cardiologyApp.service('cardiologyServices', function () {

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
    this.cardiologyData = function (cardiology) {
        debugger;
        this.CardioID = cardiology ? cardiology.CardioID : null;
        this.PatientVisitID = cardiology ? cardiology.PatientVisitID : null;
        this.Echogencity = cardiology ? cardiology.Echogencity : null;
        this.Orgid = cardiology ? cardiology.Orgid : null;
        this.AO = cardiology ? cardiology.AO : null;
        this.LA = cardiology ? cardiology.LA : null;
        this.RVID = cardiology ? cardiology.RVID : null;
        this.LVID_one = cardiology ? cardiology.LVID_one : null;
        this.LVID_Two = cardiology ? cardiology.LVID_Two : null;
        this.IVS = cardiology ? cardiology.IVS : null;
        this.LVPW = cardiology ? cardiology.LVPW : null;
        this.EF = cardiology ? cardiology.EF : null;
        this.FS = cardiology ? cardiology.FS : null;
        this.MitralValue_AML = cardiology ? cardiology.MitralValue_AML : null;
        this.MitralValue_PML = cardiology ? cardiology.MitralValue_PML : null;
        this.IntratrialSeptom = cardiology ? cardiology.IntratrialSeptom : null;
        this.IntervendicularSeptom = cardiology ? cardiology.IntervendicularSeptom : null;
        this.AorticValue = cardiology ? cardiology.AorticValue : null;
        this.PulmonaryArtory = cardiology ? cardiology.PulmonaryArtory : null;
        this.TricuspidValue = cardiology ? cardiology.TricuspidValue : null;
        this.Aortia = cardiology ? cardiology.Aortia : null;
        this.PulmonaryValue = cardiology ? cardiology.PulmonaryValue : null;
        this.RightAtrium = cardiology ? cardiology.RightAtrium : null;
        this.LeftAtrium = cardiology ? cardiology.LeftAtrium : null;
        this.RightVendricle = cardiology ? cardiology.RightVendricle : null;
        this.Pericardiam = cardiology ? cardiology.Pericardiam : null;
        this.Dopplerstudies = cardiology ? cardiology.Dopplerstudies : null;
        this.Impression = cardiology ? cardiology.Impression : null;
        this.RefferedBy = cardiology ? cardiology.RefferedBy : null;
        this.CreatedBy = cardiology ? cardiology.CreatedBy : null;
        this.CreatedAt = cardiology ? cardiology.CreatedAt : null;
        this.ModifyBy = cardiology ? cardiology.ModifyBy : null;
        this.ModiyDate = cardiology ? cardiology.ModiyDate : null;
        this.KEY = cardiology ? cardiology.KEY : null;

        //PRINT------------
        this.DOCTORNAME = cardiology ? cardiology.DOCTORNAME : null;
        this.SPECIALITY = cardiology ? cardiology.SPECIALITY : null;
        this.email_address = cardiology ? cardiology.email_address : null;
        this.DMOBILENO = cardiology ? cardiology.DMOBILENO : null;
        this.OrgDisplayAddress = cardiology ? cardiology.OrgDisplayAddress : null;
        this.PatientName = cardiology ? cardiology.PatientName : null;
        this.Age = cardiology ? cardiology.Age : null;
        this.Sex = cardiology ? cardiology.Sex : null;
        this.Current_address = cardiology ? cardiology.Current_address : null;
        this.PMobileno = cardiology ? cardiology.PMobileno : null;

    };
    this.Savepatientreg = function (data) {
        debugger;
        this.url = "Task/Savepatientreg";
        this.param = JSON.stringify(data);
    };

    this.Savecardiology = function (data) {
        debugger;
        this.url = "Task/Savecardiology";
        this.param = JSON.stringify(data);
    };

    this.PrintCordiology = function (consultation) {
        debugger;
        this.url = "Task/PrintCordiology";
        this.param = JSON.stringify(consultation);
    };
    this.BindCity = function (data) {
        debugger;
        this.url = "Task/BindCity";
        this.param = JSON.stringify(data);
    };

    this.ListCardiologydetail = function (cardiology) {
        debugger;
        this.url = "Task/BindListCardiology";
        this.param = JSON.stringify(cardiology);
    };
    this.DeleteCardiology = function (data) {
        debugger;
        this.url = "Task/DeleteCardiology";
        this.param = JSON.stringify(data);
    };
});
