async function get_companies(url)
{
    var response = await fetch(url);
    if (!response.ok) return Promise.reject(0);
    return response.json();
}

async function add_company(data)
{
    var response;

    await $.ajax({
        type: "POST",
        url: "/api/v1/company",
        async: true,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        traditional: true
    })
        .done(function () {
            response = true;
        })
        .fail(function (data, textStatus, xhr) {
            response = textStatus;
        })
        .always(function () {
            if (response == "error") {
                alert('Bad Response!');
            }
        });

    return response;
}

async function fill_main_table()
{
    var data = await get_companies('/api/v1/companies');
    if (data == 'empty') return;
    var html = '';

    for (var i = 0; i < data.length; i++)
    {
        var style = 'border_less';
        if (i === data.length - 1) style = 'border_last';
        var r = data[i];
        var state = get_state(r.state);
        html += `<tr class="${style}"><td scope="row"><a href="/companies/details?id=${r.id}">${r.name}</a></td><td>${r.city}</td><td>${state}</td><td>${r.tel}</td></tr>`;
    }

    $('#table_content').html(html);
}

function load_modal_states()
{
    var states = get_states();
    if ('undefined' === states) return;

    var html = '';

    for (var [key, value] of Object.entries(states))
    {
        html += `<option value="${key}">${value}</option>`;
    }

    $('#states').html(html);
}

timeOut = 6000;

function form_to_obj(target) {
    var formData = new FormData(target);
    var formDataObj = {};
    formData.forEach((value, key) => (formDataObj[key] = value));
    return formDataObj;
}

async function handle_add_new(event)
{
    event.preventDefault();

    var data = form_to_obj(event.target);
    var output = $("#add_result");

    var dataCheckResult = validate_data('c', data);
    if (dataCheckResult != 'ok') {
        output
            .text(`Error: ${dataCheckResult}`)
            .attr('class', 'alert alert-danger')
            .show()
            .fadeOut(timeOut);
    }
    else {
        var result = await add_company(data);

        if (result)
        {
            fill_main_table();
            $('#addNewCompany').modal('hide');
        }
    }
}

$(document).ready(function ()
{
    fill_main_table();
    load_modal_states();

    $(document).on('click', '#addNewItem', function ()
    {
        $('#addNewCompany').modal('show');
    });

    $(document).on("submit", "#addNewItemForm", handle_add_new);

    $(document).on('click', '#editItem', function ()
    {
        $('#edit_info')
            .text("Info: in order to edit company details click on Company name")
            .attr('class', 'alert alert-info')
            .show()
            .fadeOut(timeOut);
    });
});