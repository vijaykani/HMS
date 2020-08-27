PatienthistoryApp.controller('PatienthistoryCtrl', function (Excel, $timeout, $scope, $filter, PatienthistoryServices, commonService, DTOptionsBuilder, DTColumnBuilder, DTColumnDefBuilder) {
    $scope.PatientReportList = [];
    $scope.Initialize = true;
    var patientIdvital;

    $scope.init = function () {
        $scope.IsListDivVisible = false;
    };

    $scope.DatatableInitialize = function () {
        $scope.vm = {};
        $scope.vm.dtOptions = DTOptionsBuilder.newOptions().withOption('order', [0, 'asc']);
    };

    $scope.FetchPatientHistoryReport = function (data) {
        debugger;
        var request = new PatienthistoryServices.FetchPatientHistoryReport(data);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PatientReportList = [];
            $scope.PatientReportList = response.lipatienthistory;
            //$('#iReport').attr('src', '../RDLCReports/InvoiceCasewise.aspx?sInvoiceNo=' + response.liInvoicePreview[0].INVOICE_NUMBER);
            $scope.IsListDivVisible = true;
            if ($scope.Initialize) {
                $scope.DatatableInitialize();
                $scope.Initialize = false;
            }
        });
    };

    $scope.Patienthistory = function (row) {
        debugger;
        $scope.Print = true;
        //$scope.IsListDivVisible = false;
        patientIdvital = row.PatientVisitID;
        $scope.PrintConsulation();
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



    $scope.PrintConsulation = function (PatienthistoryData) {
        debugger;
        ////  $scope.Print = true;
        $scope.obj = new PatienthistoryServices.PatienthistoryData(null);
        $scope.obj.PatientVisitID = patientIdvital;

        var request = new PatienthistoryServices.Printdetail($scope.obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PrintList = response.liprintdetails;
            $('#lblDocNam').text(response.liprintdetails[0].DOCTORNAME);
            $('#lblspeciality').text(response.liprintdetails[0].SPECIALITY);
            $('#lbladdress').text(response.liprintdetails[0].OrgDisplayAddress);
            $('#lblemaildoctor').text(response.liprintdetails[0].email_address);
            $('#lbldmobileno').text(response.liprintdetails[0].DMOBILENO);
            $('#lblpname').text(response.liprintdetails[0].PatientName);
            $('#lblage').text(response.liprintdetails[0].Age);
            $('#lblsex').text(response.liprintdetails[0].Sex);
            $('#lblpmobileno').text(response.liprintdetails[0].PMobileno);
            $('#lblBP').text(response.liprintdetails[0].BP_systolic);
            $('#lblBPdia').text(response.liprintdetails[0].BP_Diastolic);
            $('#lbldreport').text(response.liprintdetails[0].Doctorreport);


        });
        $scope.DatatableInitialize();
        $scope.PrintConsulationdrug();
    };


    $scope.PrintConsulationdrug = function () {
        debugger;
        $scope.Print = true;
        $scope.obj = new PatienthistoryServices.PatienthistoryData(null);
        $scope.obj.PatientVisitID = patientIdvital;
        var request = new PatienthistoryServices.Printdetaildrug($scope.obj);
        commonService.postWebService(request.url, request.param).then(function (response) {
            $scope.PrintList = response.liprintdetails;
        });
        $scope.DatatableInitialize();
    };


    $scope.CancelPatientReport = function () {
        $scope.init();
        $scope.obj = null;
        $scope.IsListDivVisible = false;
    };

    $scope.exportToExcel = function (tableId) { // ex: '#my-table'
        debugger;
        var exportHref = Excel.tableToExcel(tableId, 'madasamy');
        $timeout(function () {
            var a = document.createElement('a');
            a.href = exportHref;
            a.download = "PatientHistory.xls";
            document.body.appendChild(a);
            a.click();
            a.remove();
        }, 100); // trigger download
    };
    $scope.exportToPDF = function (tableId) {
        debugger;
        html2canvas(document.getElementById(tableId), {
            onrendered: function (canvas) {
                debugger;
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        width: 500
                    }]
                };
                pdfMake.createPdf(docDefinition).download("PatientHistory.pdf");
            }
        });
    };

    $scope.getscreenshot = function (div, name)
     {
        html2canvas(document.getElementById(div), {
            onrendered: function (canvas) {
                var data = canvas.toDataURL();
                var docDefinition = {
                    content: [{
                        image: data,
                        width: 5000,
                    }]
                };
                pdfMake.createPdf(docDefinition).download(name + ".pdf");
            }
        });
    }

    //function export_div()
        $scope.export_div = function ()
    {

        var pdf = new jsPDF("p", "pt", "a4");
        pdf.addHTML($('#test'), 15, 15, function () {
            pdf.save('div.pdf');
        });
    }



});