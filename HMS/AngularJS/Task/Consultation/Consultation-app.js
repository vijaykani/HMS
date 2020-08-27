var consultationApp = angular.module('consultationApp', ['datatables', 'commonApp']);

consultationApp.service('consultationServices', function () {

    this.consultationData = function (consultation) {
        debugger;
        this.Patient_Id = consultation ? consultation.Patient_Id : null;
        this.Patient_no = consultation ? consultation.Patient_no : null;
        this.Title_id = consultation ? consultation.Title_id : null;
        
        this.critical_info = consultation ? consultation.critical_info : null;
        this.Referred_by = consultation ? consultation.Referred_by : null;
        this.Email = consultation ? consultation.Email : null;
        this.FirstName = consultation ? consultation.FirstName : null;
        this.FullName = consultation ? consultation.FullName : null;
        this.Lastname = consultation ? consultation.Lastname : null;
        this.Gender = consultation ? consultation.Gender : null;
        this.DOB = consultation ? consultation.DOB : null;
        this.Occupation = consultation ? consultation.Occupation : null;
        this.Blood_Group = consultation ? consultation.Blood_Group : null;
        this.Marital_Status = consultation ? consultation.Marital_Status : null;
        this.Home_address = consultation ? consultation.Home_address : null;
        this.Current_address = consultation ? consultation.Current_address : null;
        this.ISACTIVE = consultation ? consultation.ISACTIVE : null;
        this.country = consultation ? consultation.country : null;
        this.state = consultation ? consultation.state : null;
        this.City = consultation ? consultation.City : null;
        this.Mobileno = consultation ? consultation.Mobileno : null;
        this.Ethnicity = consultation ? consultation.Ethnicity : null;
        this.Org_id = consultation ? consultation.Org_id : null;
        this.Insertby = consultation ? consultation.Insertby : null;
        this.Insert_Date = consultation ? consultation.Insert_Date : null;
        this.Modify_date = consultation ? consultation.Modify_date : null;
        //Diagnosis details---------
        this.Patient_Diagnosisid = consultation ? consultation.Patient_Diagnosisid : null;
        this.Patient_Visitid = consultation ? consultation.Patient_Visitid : null;
        this.Diagnosis_title = consultation ? consultation.Diagnosis_title : null;
        this.Diagnosis_desc = consultation ? consultation.Diagnosis_desc : null;
        this.Orgid = consultation ? consultation.Orgid : null;
        this.CreatedBy = consultation ? consultation.CreatedBy : null;
        this.CreatedAt = consultation ? consultation.CreatedAt : null;
        this.ModifyBy = consultation ? consultation.ModifyBy : null;
        this.ModiyDate = consultation ? consultation.ModiyDate : null;
        this.KEY = consultation ? consultation.KEY : null;
        //--------------------------
        //Prescription details-----------
        this.PatientdrugDetailID = consultation ? consultation.PatientdrugDetailID : null;
        this.Drug_id = consultation ? consultation.Drug_id : null;
        this.strength = consultation ? consultation.strength : null;
        this.Directionforuse = consultation ? consultation.Directionforuse : null;
        this.Quantity = consultation ? consultation.Quantity : null;
        this.Doses_id = consultation ? consultation.Doses_id : null;
        this.DrugName = consultation ? consultation.DrugName : null;
        this.Dose_qty = consultation ? consultation.Dose_qty : null;
        //--------------------

        //Test details---------
        this.Patient_Testdetailid = consultation ? consultation.Patient_Testdetailid : null;
        //  this.Patient_Visitid = consultation ? consultation.Patient_Visitid : null;
        this.Test_id = consultation ? consultation.Test_id : null;
        this.Test_details = consultation ? consultation.Test_details : null;
        this.InvName = consultation ? consultation.InvName : null;
        this.Test_Uploadpath = consultation ? consultation.Test_Uploadpath : null;
        this.Test_Uploadfilename = consultation ? consultation.Test_Uploadfilename : null;
        this.Test_Upload = consultation ? consultation.PatientdrugDetailID : null;

        //---------------------------

        //vitals details----
        // this.PatientID = consultation ? consultation.PatientID : null;
        this.Visit_Type = consultation ? consultation.Visit_Type : null;
        this.PhysicianID = consultation ? consultation.PhysicianID : null;
        this.BP_systolic = consultation ? consultation.BP_systolic : null;
        this.BP_Diastolic = consultation ? consultation.BP_Diastolic : null;
        this.Temperature = consultation ? consultation.Temperature : null;
        this.Pulse = consultation ? consultation.Pulse : null;
        this.Respiratory_rate = consultation ? consultation.Respiratory_rate : null;
        this.Weight = consultation ? consultation.Weight : null;
        this.Height = consultation ? consultation.Height : null;
        this.Visitdate = consultation ? consultation.Visitdate : null;
        this.VisitNumber = consultation ? consultation.VisitNumber : null;
        this.PatientVisitID = consultation ? consultation.PatientVisitID : null;
        this.Doctorreport = consultation ? consultation.Doctorreport : null;
        this.NextVisitDate = consultation ? consultation.NextVisitDate : null;
        this.Patient_VitalsID = consultation ? consultation.Patient_VitalsID : null;
        this.Symtoms = consultation ? consultation.Symtoms : null;
        //---------------------------print details-----------------
        this.DOCTORNAME = consultation ? consultation.DOCTORNAME : null;
        this.SPECIALITY = consultation ? consultation.SPECIALITY : null;
        this.OrgDisplayAddress = consultation ? consultation.OrgDisplayAddress : null;
        this.PatientName = consultation ? consultation.PatientName : null;
        this.Age = consultation ? consultation.Age : null;
        this.email_address = consultation ? consultation.email_address : null;
        this.DMOBILENO = consultation ? consultation.DMOBILENO : null;
        this.PMobileno = consultation ? consultation.PMobileno : null;

    };

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

    this.SaveDiagnosismaster = function (data) {
        debugger;
        this.url = "Task/SaveDiagnosismaster";
        this.param = JSON.stringify(data);
    };
    this.ListDiagnosisdetail = function (consultation) {
        debugger;
        this.url = "Task/BindListDiagnosisdetail";
        this.param = JSON.stringify(consultation);
    };
    this.Printdetail = function (consultation) {
        debugger;
        this.url = "Task/Printdetail";
        this.param = JSON.stringify(consultation);
    };
    this.Sendmail = function (data) {
        debugger;
        this.url = "Task/sendmail";
        this.param = JSON.stringify(data);
    };
    this.Printdetaildrug = function (consultation) {
        debugger;
        this.url = "Task/Printdetaildrug";
        this.param = JSON.stringify(consultation);
    };
    this.ListDrugdetail = function (consultation) {
        debugger;
        this.url = "Task/BindListDrugdetail";
        this.param = JSON.stringify(consultation);
    };
    this.ListTestdetail = function (consultation) {
        debugger;
        this.url = "Task/BindListTestdetail";
        this.param = JSON.stringify(consultation);
    };

    this.ListVitalsdetail = function (consultation) {
        debugger;
        this.url = "Task/BindListVitalsdetail";
        this.param = JSON.stringify(consultation);
    };
    this.SavePrecriptionmaster = function (data) {
        debugger;
        this.url = "Task/SavePrecriptionmaster";
        this.param = JSON.stringify(data);
    };
    this.SaveTestmaster = function (data) {
        debugger;
        this.url = "Task/SaveTestmaster";
        this.param = JSON.stringify(data);
    };
    this.SaveVitalsmaster = function (data) {
        debugger;
        this.url = "Task/SaveVitalsmaster";
        this.param = JSON.stringify(data);
    };

    this.SavePrescript = function (consultation) {
        debugger;
        this.url = "Task/SavePrescript";
        this.param = JSON.stringify(consultation);
    };
    this.DeleteDiagnosisMaster = function (data) {
        debugger;
        this.url = "Task/DeleteDiagnosisMaster";
        this.param = JSON.stringify(data);
    };
    this.DeleteVitalsMaster = function (data) {
        debugger;
        this.url = "Task/DeleteVitalsMaster";
        this.param = JSON.stringify(data);
    };
    this.DeletePrecriptionMaster = function (data) {
        debugger;
        this.url = "Task/DeletePrecriptionMaster";
        this.param = JSON.stringify(data);
    };
    this.DeleteTestMaster = function (data) {
        debugger;
        this.url = "Task/DeleteTestMaster";
        this.param = JSON.stringify(data);
    };
});
