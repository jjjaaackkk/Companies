async function fetch_api(url)
{
    var response = await fetch(url);
    if (!response.ok) return Promise.reject(0);
    return response.json();
}

async function send_ajax(url, metod, data = 0)
{
    var response;

    await $.ajax({
        url: url,
        type: metod,
        data: data,
        success: function (result) {
            response = result;
        },
        fail: function (xhr, status, error) {
            response = status;
        }
    });

    return response;
}

async function delete_data(url)
{
    var response;

    await $.ajax({
        url: url,
        type: 'DELETE',
        success: function (result) {
            response = true;
        },
        fail: function () {
            response = false;
        }
    });

    return response;
}

async function handle_note_remove(id)
{
    var status = await delete_data(`/api/v1/note/${id}`);
    if (status)
    {
        fill_history();
        fill_notes();
    }
}

async function handle_emp_remove(id)
{
    var status = await delete_data(`/api/v1/employee/${id}`);
    if (status)
    {
        fill_employees();
        load_first_employee();
    }
}

function get_id()
{
    if ('undefined' === window.__CompanyId) return;
    return window.__CompanyId
}

async function fill_info()
{
    var id = get_id();

    var data = await fetch_api(`/api/v1/company/${id}`);
    if (data === 0) return;

    var fields = 'id,name,address,city,state,tel'.split(',');

    for (var field of fields)
    {
        var value = data[field];

        if (field == 'name') $('#company_name').html(value);
        else if (field == 'state') value = get_state(value);

        $(`#comp_${field}`).val(value);
    }
}

function format_date(date)
{
    date = Date.parse(date);
    date = new Date(date);
    var d = [
        date.getFullYear(),
        date.getMonth() + 1,
        date.getDate(),
        date.getHours(),
        date.getMinutes(),
        date.getSeconds(),
    ];

    return `${d[1]}/${d[2]}/${d[0]}`
}

async function load_employee(id) {
    var data = await fetch_api(`/api/v1/employee/${id}`);
    if (data === 0) return;

    var fields = 'id,first,last,titleId,dob,positionId'.split(',');

    for (var field of fields) {
        var value = data[field];

        if (field.includes('Id')) {
            field = field.split('Id')[0];
            $(`#emp_${field}`).val(value);
        }

        if (field == 'dob') value = format_date(value);

        $(`#emp_${field}`).val(value);
    }
}

async function load_first_employee() {
    var id = get_id();
    var emps = await fetch_api(`/api/v1/company/${id}/employees`);
    if (emps === 0) return;

    load_employee(emps[0].id);
}

async function fill_history()
{
    var id = get_id();

    $('#history_table').html('');

    var notes = await fetch_api(`/api/v1/company/${id}/notes`);
    if (notes === 0) return;

    var html = '';
    for (var n of notes)
    {
        var date = format_date(n.orderDate);
        html += `<tr><td scope="row">${date}</td><td>${n.storeCity}</td></tr>`;
    }
    $('#history_table').html(html);
}

function id2employee(emps, empId)
{
    for (var emp of emps)
    {
        if (emp.id == empId) return emp;
    }
    return 0;
}

async function fill_notes()
{
    var id = get_id();

    $('#notes_table').html('');

    var notes = await fetch_api(`/api/v1/company/${id}/notes`);
    if (notes === 0) return;

    var emps = await fetch_api(`/api/v1/company/${id}/employees`);
    if (emps === 0) return;

    var html = '';
    for (var n of notes) {

        var emp = id2employee(emps, n.id);
        if (emp === 0) continue;

        var trash = `<a onclick="handle_note_remove(${n.id});"><i class="fa fa-trash fa-1x" aria-hidden="true"></i></a>`;
        html += `<tr><td scope="row" class="td-right">${n.invoidId}</td><td>${emp.first} ${emp.last}</td><td class="td-center">${trash}</td></tr>`;
    }
    $('#notes_table').html(html);
}

async function fill_employees()
{
    var id = get_id();

    $('#emp_table').html('');
    $('#employees').empty();

    var emps = await fetch_api(`/api/v1/company/${id}/employees`);
    if (emps === 0) return;

    var html = '';
    for (var e of emps)
    {
        var edit = `<a onclick="load_employee(${e.id});"><i class="fa fa-pencil-square fa-1x" aria-hidden="true"></i></a>`;
        var trash = `<a onclick="handle_emp_remove(${e.id});"><i class="fa fa-trash fa-1x" aria-hidden="true"></i></a>`;
        html += `<tr><td scope="row">${e.first}</td><td>${e.last}</td><td class="td-center">${edit}&nbsp;${trash}</td></tr>`;
    }
    $('#emp_table').html(html);

    var select = '#employees';
    $(select).empty();

    var select_items = [];

    for (var e of emps)
    {
        var obj = {};
        obj.id = e.id;
        obj.name = `${e.first} ${e.last}`;
        select_items.push(obj);
    }

    fill_select(select_items, select);

}

async function add_note()
{
    $('#addNewNote').modal('show');
}

async function add_employee()
{
    $('#addNewEmployee').modal('show');
}

timeOut = 4000;
async function handle_edit(url, ser, output)
{
    var result = await send_ajax(url, 'PUT', ser);

    if (result == "success") {
        output
            .text("Success!")
            .attr('class', 'alert alert-success')
            .show()
            .fadeOut(timeOut);
        return true;
    }
    else {
        output
            .text("Failure: " + result)
            .attr('class', 'alert alert-danger')
            .show()
            .fadeOut(timeOut);
        return false;
    }
}

async function handle_new(url, ser, output)
{
    var result = await send_ajax(url, 'POST', ser);

    if (result == "success") {
        output
            .text("Success!")
            .attr('class', 'alert alert-success')
            .show()
            .fadeOut(timeOut);
        return true;
    }
    else {
        output
            .text("Failure: " + result)
            .attr('class', 'alert alert-danger')
            .show()
            .fadeOut(timeOut);
        return false;
    }
}

function fill_select(values, el)
{
    $(el).html('');

    if ('undefined' === values) return;

    var html = '';

    for (var v of values) {
        html += `<option value="${v.id}">${v.name}</option>`;
    }

    $(el).html(html);
}

async function handle_add_note(url, data, output)
{
    var result = await handle_new(url, data, output);

    if (result)
    {
        fill_history();
        fill_notes();
    }
}

async function handle_add_employee(url, data, output)
{
    var result = await handle_new(url, data, output);

    if (result)
    {
        fill_employees();
        load_first_employee();
    }
}

async function prepare_page_data()
{
    window.__CompanyId = window.location.search.split('=')[1];

    window.__Titles = await fetch_api(`/api/v1/titles`);
    fill_select(window.__Titles, '.titles');
    window.__Positions = await fetch_api(`/api/v1/positions`);
    fill_select(window.__Positions, '.positions');

}

$(document).ready(function ()
{
    prepare_page_data();
    fill_info();
    fill_history();
    fill_notes();
    fill_employees();
    load_first_employee();

    $(document).on('click', '#info_edit', function()
    {
        var id = get_id();

        var name = $('#comp_name').val();
        var address = $('#comp_address').val();
        var city = $('#comp_city').val();
        var state = $('#comp_state').val();
        var code = get_state_code(state).toUpperCase();
        var tel = $('#comp_tel').val();

        var url = `/api/v1/company/${id}`;
        var ser = `name=${name}&address=${address}&city=${city}&state=${code}&tel=${tel}`;
        var output = $('#info_result');

        handle_edit(url, ser, output);
    });

    $(document).on('click', '#emp_edit', function ()
    {
        var id = $('#emp_id').val();
        var first = $('#emp_first').val();
        var last = $('#emp_last').val();
        var title = $('#emp_title').val();
        var dob = $('#emp_dob').val();
        var position = $('#emp_position').val();

        var url = `/api/v1/employee/${id}`;
        var ser = `first=${first}&last=${last}&title=${title}&dob=${dob}&position=${position}`;
        var output = $('#emp_result');

        handle_edit(url, ser, output);
    });

    $(document).on("submit", "#addNewNoteForm", function (event)
    {
        event.preventDefault();

        $('#note_comp').val(get_id());

        var url = `/api/v1/note`;
        var ser = $(this).serialize();
        var output = $('#note_result');

        handle_add_note(url, ser, output);
    });

    $(document).on("submit", "#addNewEmployeeForm", function (event) {
        event.preventDefault();

        $('#emp_comp').val(get_id());

        var url = `/api/v1/employee`;
        var ser = $(this).serialize();
        var output = $('#new_emp_result');

        handle_add_employee(url, ser, output);
    });
});