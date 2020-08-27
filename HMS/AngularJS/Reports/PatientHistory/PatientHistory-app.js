var PatienthistoryApp = angular.module('PatienthistoryApp', ['datatables', 'commonApp']);

PatienthistoryApp.service('PatienthistoryServices', function () {

    this.PatienthistoryData = function (Patienthistory) {
        this.Patient_Id = Patienthistory ? Patienthistory.Patient_Id : null;
        this.Patient_no = Patienthistory ? Patienthistory.Patient_no : null;
        this.Title_id = Patienthistory ? Patienthistory.Title_id : null;
        this.critical_info = Patienthistory ? Patienthistory.critical_info : null;
        this.Referred_by = Patienthistory ? Patienthistory.Referred_by : null;
        this.Email = Patienthistory ? Patienthistory.Email : null;
        this.FirstName = Patienthistory ? Patienthistory.FirstName : null;
        this.FullName = Patienthistory ? Patienthistory.FullName : null;
        this.Lastname = Patienthistory ? Patienthistory.Lastname : null;
        this.Gender = Patienthistory ? Patienthistory.Gender : null;
        this.DOB = Patienthistory ? Patienthistory.DOB : null;
        this.Occupation = Patienthistory ? Patienthistory.Occupation : null;
        this.Blood_Group = Patienthistory ? Patienthistory.Blood_Group : null;
        this.Marital_Status = Patienthistory ? Patienthistory.Marital_Status : null;
        this.Home_address = Patienthistory ? Patienthistory.Home_address : null;
        this.Current_address = Patienthistory ? Patienthistory.Current_address : null;
        this.ISACTIVE = Patienthistory ? Patienthistory.ISACTIVE : null;
        this.country = Patienthistory ? Patienthistory.country : null;
        this.state = Patienthistory ? Patienthistory.state : null;
        this.City = Patienthistory ? Patienthistory.City : null;
        this.Mobileno = Patienthistory ? Patienthistory.Mobileno : null;
        this.Ethnicity = Patienthistory ? Patienthistory.Ethnicity : null;
        this.Org_id = Patienthistory ? Patienthistory.Org_id : null;
        this.Insertby = Patienthistory ? Patienthistory.Insertby : null;
        this.Insert_Date = Patienthistory ? Patienthistory.Insert_Date : null;
        this.Modify_date = Patienthistory ? Patienthistory.Modify_date : null;
        //Diagnosis details---------
        this.Patient_Diagnosisid = Patienthistory ? Patienthistory.Patient_Diagnosisid : null;
        this.Patient_Visitid = Patienthistory ? Patienthistory.Patient_Visitid : null;
        this.Diagnosis_title = Patienthistory ? Patienthistory.Diagnosis_title : null;
        this.Diagnosis_desc = Patienthistory ? Patienthistory.Diagnosis_desc : null;
        this.Orgid = Patienthistory ? Patienthistory.Orgid : null;
        this.CreatedBy = Patienthistory ? Patienthistory.CreatedBy : null;
        this.CreatedAt = Patienthistory ? Patienthistory.CreatedAt : null;
        this.ModifyBy = Patienthistory ? Patienthistory.ModifyBy : null;
        this.ModiyDate = Patienthistory ? Patienthistory.ModiyDate : null;
        this.KEY = Patienthistory ? Patienthistory.KEY : null;
        //--------------------------
        //Prescription details-----------
        this.PatientdrugDetailID = Patienthistory ? Patienthistory.PatientdrugDetailID : null;
        this.Drug_id = Patienthistory ? Patienthistory.Drug_id : null;
        this.strength = Patienthistory ? Patienthistory.strength : null;
        this.Directionforuse = Patienthistory ? Patienthistory.Directionforuse : null;
        this.Quantity = Patienthistory ? Patienthistory.Quantity : null;
        this.Doses_id = Patienthistory ? Patienthistory.Doses_id : null;
        this.DrugName = Patienthistory ? Patienthistory.DrugName : null;
        this.Dose_qty = Patienthistory ? Patienthistory.Dose_qty : null;
        //--------------------

        //Test details---------
        this.Patient_Testdetailid = Patienthistory ? Patienthistory.Patient_Testdetailid : null;
        //  this.Patient_Visitid = Patienthistory ? Patienthistory.Patient_Visitid : null;
        this.Test_id = Patienthistory ? Patienthistory.Test_id : null;
        this.Test_details = Patienthistory ? Patienthistory.Test_details : null;
        this.InvName = Patienthistory ? Patienthistory.InvName : null;
        this.Test_Uploadpath = Patienthistory ? Patienthistory.Test_Uploadpath : null;
        this.Test_Uploadfilename = Patienthistory ? Patienthistory.Test_Uploadfilename : null;
        this.Test_Upload = Patienthistory ? Patienthistory.PatientdrugDetailID : null;

        //---------------------------

        //vitals details----
        // this.PatientID = Patienthistory ? Patienthistory.PatientID : null;
        this.Visit_Type = Patienthistory ? Patienthistory.Visit_Type : null;
        this.PhysicianID = Patienthistory ? Patienthistory.PhysicianID : null;
        this.BP_systolic = Patienthistory ? Patienthistory.BP_systolic : null;
        this.BP_Diastolic = Patienthistory ? Patienthistory.BP_Diastolic : null;
        this.Temperature = Patienthistory ? Patienthistory.Temperature : null;
        this.Pulse = Patienthistory ? Patienthistory.Pulse : null;
        this.Respiratory_rate = Patienthistory ? Patienthistory.Respiratory_rate : null;
        this.Weight = Patienthistory ? Patienthistory.Weight : null;
        this.Height = Patienthistory ? Patienthistory.Height : null;
        this.Visitdate = Patienthistory ? Patienthistory.Visitdate : null;
        this.VisitNumber = Patienthistory ? Patienthistory.VisitNumber : null;
        this.PatientVisitID = Patienthistory ? Patienthistory.PatientVisitID : null;
        this.Doctorreport = Patienthistory ? Patienthistory.Doctorreport : null;
        this.NextVisitDate = Patienthistory ? Patienthistory.NextVisitDate : null;
        this.Patient_VitalsID = Patienthistory ? Patienthistory.Patient_VitalsID : null;
        this.Symtoms = Patienthistory ? Patienthistory.Symtoms : null;
        //---------------------------print details-----------------
        this.DOCTORNAME = Patienthistory ? Patienthistory.DOCTORNAME : null;
        this.SPECIALITY = Patienthistory ? Patienthistory.SPECIALITY : null;
        this.OrgDisplayAddress = Patienthistory ? Patienthistory.OrgDisplayAddress : null;
        this.PatientName = Patienthistory ? Patienthistory.PatientName : null;
        this.Age = Patienthistory ? Patienthistory.Age : null;
        this.email_address = Patienthistory ? Patienthistory.email_address : null;
        this.DMOBILENO = Patienthistory ? Patienthistory.DMOBILENO : null;
        this.PMobileno = Patienthistory ? Patienthistory.PMobileno : null;

    };

    this.FetchPatientHistoryReport = function (data) {
        debugger;
        this.url = "Reports/FetchPatienthistory";
        this.param = JSON.stringify(data);
    };

    this.Printdetail = function (Patienthistory) {
        debugger;
        this.url = "Task/Printdetail";
        this.param = JSON.stringify(Patienthistory);
    };

    this.Printdetaildrug = function (Patienthistory) {
        debugger;
        this.url = "Task/Printdetaildrug";
        this.param = JSON.stringify(Patienthistory);
    };

});
