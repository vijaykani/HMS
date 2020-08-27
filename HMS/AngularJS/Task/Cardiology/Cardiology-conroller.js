cardiologyApp.controller('cardiologyCtrl', function ($scope, $filter, cardiologyServices, commonService, DTOptionsBuilder, DTColumnBuilder) {
    $scope.patientregList = [];
  //  $scope.CardiologyList = [];
    $scope.StateList = [];
    $scope.CityList = [];

    $scope.obj = new cardiologyServices.cardiologyData(null);

    //$scope.obj = new cardiologyServices.patientregData(null);

    $scope.init = function () {
        debugger;
        commonService.postWebService('Task/BindListpatientreg', {}).then(function (response) {
            $scope.patientregList = response.liPatientreg;
            $scope.CityList = response.liCityMaster;
            $scope.StateList = response.liStateMaster;
            $scope.IsListDivVisible = true;
            $scope.IsEditDivVisible = false;
            $scope.IsListCardiologyVisible = false;
        });
        $scope.DatatableInitialize();
    };

    $scope.editClickCardiology = function (row, key, IsActive) {
        if (key == 'E') {
            $scope.obj = new cardiologyServices.cardiologyData(row);
            $scope.obj.KEY = key;
        }
        else {
            $scope.obj = new cardiologyServices.cardiologyData(null);
            $scope.obj.KEY = key;
        }
    };

    $scope.DeleteCardiology = function (cardiology) {
        cardiology.PatientVisitID = $scope.PatientVisitID;
        var request = new cardiologyServices.DeleteCardiology(cardiology);
        commonService.postWebService(request.url, request.param).then(function (response) {
            if (response != null && response.liCardiologyDetails[0].MSG == "Deleted Success") {
                $("#Message").val('Deleted !! ');//Messgae
                $('#Title').html('Cardiology  Details Deleted Successfully');//Title
                $("#Message").trigger("click");
                $scope.IsListCardiologyVisible = false;
                $scope.initCardiology();
                $scope.obj = null;
                $scope.CardiologyForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Deleting Category');//Title
                $("#Message").trigger("click");
            }
        });
    };

    $scope.initCardiology = function (cardiology) { 
        cardiology.PatientVisitID = $scope.PatientVisitID;
        var request = new cardiologyServices.ListCardiologydetail(cardiology);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.CardiologyList = response.liCardiologyDetails;
        });
        $scope.DatatableInitialize();
    };

    $scope.DatatableInitialize = function () {
        $scope.vm = {};
        $scope.vm.dtOptions = DTOptionsBuilder.newOptions()
		  .withOption('order', [0, 'asc']);;
    };
    $scope.Cancelpatientreg = function () {
        $scope.IsListDivVisible = true;
        $scope.IsEditDivVisible = false;
        $scope.obj = null;
        $scope.patientregForm.$setPristine();
    };

    $scope.BindCity = function (obj, key) {
        var request = new cardiologyServices.BindCity(obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;
            $scope.CityList = response.liCityMaster;
            if (key == 'E') {
                $scope.obj.City = obj.City;
            }
        });
    }

    $scope.editClickPatient = function (row, key, IsActive) {
        debugger;
        $scope.IsEditDivVisible = true;
        $scope.IsListDivVisible = false;
        if (key == 'E') {
            $scope.obj = new cardiologyServices.patientregData(row);
            $scope.obj.KEY = key;
            if (row.ISACTIVE == 'N') {
                $scope.obj.ISACTIVE = false;
            }
            else {
                $scope.obj.ISACTIVE = true;
            }
            $scope.BindCity(row, "E");
        }
        else {
            $scope.obj = new cardiologyServices.patientregData(null);
            $scope.disablecode = false;
            $scope.obj.ISACTIVE = true;
            $scope.obj.KEY = key;
        }
    };

    $scope.submitFormPatient = function (isValid, patientreg) {
        // check to make sure the form is completely valid
        debugger;
        if (isValid) {
            $scope.Savepatientreg(patientreg);
            $scope.patientregForm.$setPristine();
        }
        else {
            angular.forEach($scope.patientregForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
    };

    $scope.Savepatientreg = function (patientreg) {
        if (patientreg.ISACTIVE == true) {
            patientreg.ISACTIVE = "1";

        }
        else {
            patientreg.ISACTIVE = "0";
        }
        var request = new cardiologyServices.Savepatientreg(patientreg);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liPatientreg != null) {
                if (response.liPatientreg[0].MSG == "Updated Success") {
                    $("#Message").val('Updated !! ');//Messgae
                    $('#Title').html('Patient Details Updated Successfully' + '<br/>' + 'Patient Number :  ' + response.liPatientreg[0].Patient_no);//Title
                }
                else {
                    $("#Message").val('Saved !! ');//Messgae
                    $('#Title').html('Patient  Details Saved Successfully' + '<br/>' + 'Patient Number :  ' + response.liPatientreg[0].Patient_no);//Title
                }
                $("#Message").trigger("click");
                $scope.init();
                $scope.obj = null;

                $scope.patientregForm.$setPristine();
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Category');//Title
                $("#Message").trigger("click");
            }
        });

    };

    //$scope.submitFormCardiology = function (isValid, cardiology) {
    //    // check to make sure the form is completely valid
    //    debugger;
    //    if (isValid) {
    //        $scope.Savecardiology(cardiology);
    //        $scope.CardiologyForm.$setPristine();
    //    }
    //    else {
    //        angular.forEach($scope.CardiologyForm.$error.required, function (field) {
    //            field.$setDirty();
    //        });
    //    }
    //};

    $scope.submitFormCardiology = function (isValid, cardiology) {
        debugger;
        if (isValid) {
            if ((typeof $('input[id="checkbox-p-fill-1"]:checked').val() === 'undefined') || ($('input[id="checkbox-p-fill-1"]:checked').val() == "")) {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Select Patient List');//Title
                $("#Message").trigger("click");

            }
            else {
                $scope.Savecardiology(cardiology);
                $scope.CardiologyForm.$setPristine();
            }
        }
        else {
            angular.forEach($scope.CardiologyForm.$error.required, function (field) {
                field.$setDirty();
            });
        }
        //}
    };

    $scope.Savecardiology = function (cardiology) {
        debugger;
        cardiology.Patient_Id = $('input[id="checkbox-p-fill-1"]:checked').val();
        var request = new cardiologyServices.Savecardiology(cardiology);
        commonService.postWebService(request.url, request.param).then(function (response) {
            debugger;

            if (response.liCardiologyDetails != null) {
                if (response.liCardiologyDetails[0].MSG == "Updated Success") {
                    $("#Message").val('Updated !! ');//Messgae
                    $('#Title').html('Cardiology Details Updated Successfully');//Title
                }
                else {
                    $("#Message").val('Saved !! ');//Messgae
                    $('#Title').html('Cardiology  Details Saved Successfully');//Title
                }
                $scope.PatientVisitID = response.liCardiologyDetails[0].PatientVisitID;
                $("#Message").trigger("click");
                $scope.initCardiology(cardiology);
                $scope.obj = null;
                $scope.IsListCardiologyVisible = true;
                $scope.CardiologyForm.$setPristine();
                patientIdvital = $scope.PatientVisitID;
            }
            else {
                $("#Message").val('Failed !! ');//Messgae
                $('#Title').html('Error Happened while Saving Category');//Title
                $("#Message").trigger("click");
            }
        });

    };

    $scope.PrintS = function () {
        var printContents = document.getElementById('test').innerHTML;
        var popupWin = window.open('', 'Print-Window');
        popupWin.document.open();
        //popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="http://localhost:63438/assets/plugins/bootstrap/css/bootstrap.min.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.write('<html><head><link rel="stylesheet" type="text/css" href="../assets/plugins/bootstrap/css/bootstrap.min.css" /></head><body onload="window.print()">' + printContents + '</body></html>');
        popupWin.document.close();

        //var divToPrint = document.getElementById('test');
        //var newWin = window.open('', 'Print-Window');
        //newWin.document.open();
        ////newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

        //newWin.document.close();
        //setTimeout(function () { newWin.close(); }, 1);
    }

    $scope.PrintCardiology = function (cardiology) {
        debugger;
        $scope.Print = true;
         $scope.obj = new cardiologyServices.cardiologyData(null);
        $scope.obj.PatientVisitID = patientIdvital;

        var request = new cardiologyServices.PrintCordiology($scope.obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PrintList = response.liCardiologyDetails;
            $('#lblDocNam').text(response.liCardiologyDetails[0].DOCTORNAME);
            $('#lblEF').text(response.liCardiologyDetails[0].EF);
            $('#lblLA').text(response.liCardiologyDetails[0].LA);
            $('#lblspeciality').text(response.liCardiologyDetails[0].SPECIALITY);
            $('#lbladdress').text(response.liCardiologyDetails[0].OrgDisplayAddress);
            $('#lblemaildoctor').text(response.liCardiologyDetails[0].email_address);
            $('#lbldmobileno').text(response.liCardiologyDetails[0].DMOBILENO);
            $('#lblpname').text(response.liCardiologyDetails[0].PatientName);
            $('#lblage').text(response.liCardiologyDetails[0].Age);
            $('#lblsex').text(response.liCardiologyDetails[0].Sex);
            $('#lblpmobileno').text(response.liCardiologyDetails[0].PMobileno);
            $('#lblAO').text(response.liCardiologyDetails[0].AO);
            $('#lblIVS').text(response.liCardiologyDetails[0].IVS);
            $('#lblLVPW').text(response.liCardiologyDetails[0].LVPW);
            $('#lblRVID').text(response.liCardiologyDetails[0].RVID);
            $('#lblLVID1').text(response.liCardiologyDetails[0].LVID_one);
            $('#lblFS').text(response.liCardiologyDetails[0].FS);
            $('#lblLVID2').text(response.liCardiologyDetails[0].LVID_Two);
            $('#lblAML').text(response.liCardiologyDetails[0].MitralValue_AML);
            $('#lblINTER').text(response.liCardiologyDetails[0].IntratrialSeptom);
            $('#lblPML').text(response.liCardiologyDetails[0].MitralValue_PML);
            $('#lblVENSEPTUM').text(response.liCardiologyDetails[0].IntervendicularSeptom);
            $('#lblARITO').text(response.liCardiologyDetails[0].AorticValue);
            $('#lblPULMOMORY').text(response.liCardiologyDetails[0].PulmonaryArtory);
            $('#lblTRICUSPID').text(response.liCardiologyDetails[0].TricuspidValue);
            $('#lblAORTA').text(response.liCardiologyDetails[0].Aortia);
            $('#lblPULMONARYVAL').text(response.liCardiologyDetails[0].PulmonaryValue);
            $('#lblRIGHTATRIUM').text(response.liCardiologyDetails[0].RightAtrium);
            $('#lblRIGHTVEN').text(response.liCardiologyDetails[0].RightVendricle);
            $('#lblLATRIUM').text(response.liCardiologyDetails[0].LeftAtrium);
            $('#lblPERICARIUM').text(response.liCardiologyDetails[0].Pericardiam);
            $('#lblDOPPER').text(response.liCardiologyDetails[0].Dopplerstudies);
            $('#lblIMPRESSION').text(response.liCardiologyDetails[0].Impression);
        });
        $scope.DatatableInitialize();
        $scope.PrintConsulationdrug();
    };

    $scope.returnAcive = function (act) {
        return act == 1 ? 'Y' : 'N';
    };


    //$scope.showBankDetails = function () {

    //};

    $scope.init();
   // $scope.initCardiology(cardiology);
    
    $scope.myFunctionCompany = function (row, key) {
        $scope.obj = new cardiologyServices.patientregData(row);
        myFunctionCompany();
    }


});