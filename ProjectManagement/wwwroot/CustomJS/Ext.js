function printDiv(divId) {
    var divToPrint = document.getElementById(divId);
    var newWindow = window.open('', '', 'height=600,width=800');
    newWindow.document.write('<html><head><title>Print</title>');
    newWindow.document.write('</head><body >');
    newWindow.document.write(divToPrint.outerHTML);
    newWindow.document.write('</body></html>');
    newWindow.document.close();
    newWindow.print();
}
