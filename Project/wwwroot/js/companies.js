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
        data: data
    })
        .done(function (msg) {
            response = msg;
        })
        .fail(function (xhr, status, error) {
            response = status;
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

async function handle_add_new(event)
{
    event.preventDefault();

    var ser = $(this).serialize();
    var result = await add_company(ser);
    var output = $("#add_result");

    if (result == "success") {
        output
            .text(result)
            .attr('class', 'alert alert-success')
            .show()
            .fadeOut(timeOut);
        fill_main_table();
        $('#addNewItemForm')[0].reset();
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