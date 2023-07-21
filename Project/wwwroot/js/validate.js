function isDateValid(str) {
    var regex = /^([1-9]|1[0-2])\/([1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
    return regex.test(str)
}

function isNumberValid(str) {
    return str.match(/^\d+/)
}

function isPhoneValid(str) {
    var regex = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    return regex.test(str)
}

function validate_data(type, data) {

    if ('undefined' == type) return;
    else if (type == 'c') {
        if (!data.name) return 'Company name is empty!';
        else if (!data.address) return 'Address is empty!';
        else if (!data.city) return 'City is empty!';
        else if (!data.state) return 'State is empty or invalid!';
        else if (!data.tel) return 'Phone is empty!';
        else if (!isPhoneValid(data.tel)) return 'Phone is invalid!';
    }
    else if (type == 'e') {
        if (!data.first) return 'First name is empty!';
        else if (!data.last) return 'Last name is empty!';
        else if (!data.titleId || data.titleId < 1) return 'Title is empty!';
        else if (!data.positionId || data.positionId < 1) return 'Position is empty!';
        else if (!data.dob) return 'Date of birth is empty!';
        else if (!isDateValid(data.dob)) return 'Date of birth is invalid!';
    }
    else if (type == 'n') {
        if (!data.invoiceId) return 'Invoice is empty!';
        else if (!isNumberValid(data.invoiceId)) return 'Inovoice invalid!';
        else if (!data.employeeId || data.employeeId < 1) return 'Employee is empty!';
        else if (!data.storeCity) return 'Store city is empty!';
        else if (!isDateValid(data.orderDate)) return 'Order date is invalid!';
    }

    return 'ok';
}