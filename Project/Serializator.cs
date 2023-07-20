using Companies.Models;
using System.Globalization;

namespace Companies
{
    public class Serializator
    {
        IFormCollection Form;
        public string Error { get; set; } = "";

        public Serializator(IFormCollection form)
        {
            Form = form;
        }

        private string get_form_str(string value)
        {
            return Form[value].ToString();
        }

        private int get_form_int(string value)
        {
            var result = 0;
            value = get_form_str(value);
            int.TryParse(value, out result);
            return result;
        }

        public bool Parse(ref Company comp)
        {
            if (Form is null)
            {
                Error = "no data";
                return false;
            }

            var name = get_form_str("name");
            var address = get_form_str("address");
            var city = get_form_str("city");
            var state = get_form_str("state");
            var tel = get_form_str("tel");

            if (string.IsNullOrEmpty(name))
            {
                Error = "name invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(address))
            {
                Error = "address invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(city))
            {
                Error = "city invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(state) || state.Length > 2)
            {
                Error = "state invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(tel) || tel.Length != 10)
            {
                Error = "tel invalid";
                return false;
            }

            comp.Name = name;
            comp.Address = address;
            comp.City = city;
            comp.State = state;
            comp.Tel = tel;

            return true;
        }

        private DateTime parse_date(string dob)
        {
            DateTime Result;
            CultureInfo en_us = new CultureInfo("en-US");
            DateTime.TryParseExact(dob, "M/d/yyyy", en_us, DateTimeStyles.None, out Result);
            return Result;
        }

        public bool Parse(ref Employee emp)
        {
            if (Form == null)
            {
                Error = "no data";
                return false;
            }

            var first = get_form_str("first");
            var last = get_form_str("last");
            var title = get_form_int("title");
            var dob = parse_date(get_form_str("dob"));
            var position = get_form_int("position");
            var company = get_form_int("company");

            if (string.IsNullOrEmpty(first))
            {
                Error = "first invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(last))
            {
                Error = "last invalid";
                return false;
            }
            else if (title == 0)
            {
                Error = "title invalid";
                return false;
            }
            else if (dob == default)
            {
                Error = "date of birth invalid";
                return false;
            }
            else if (position == 0)
            {
                Error = "position invalid";
                return false;
            }

            emp.First = first;
            emp.Last = last;
            emp.TitleId = title;
            emp.DOB = dob;
            emp.PositionId = position;
            emp.CompanyId = company;

            return true;
        }

        public bool Parse(ref Note note)
        {
            if (Form == null)
            {
                Error = "no data";
                return false;
            }

            var company = get_form_int("company");
            var invoice = get_form_int("invoice");
            var employee = get_form_int("employee");
            var city = get_form_str("city");
            var date = parse_date(get_form_str("date"));

            if (company == 0)
            {
                Error = "company invalid";
                return false;
            }
            else if (invoice == 0)
            {
                Error = "invoice invalid";
                return false;
            }
            else if (employee == 0)
            {
                Error = "employee invalid";
                return false;
            }
            else if (string.IsNullOrEmpty(city))
            {
                Error = "city invalid";
                return false;
            }
            else if (date == default)
            {
                Error = "date invalid";
                return false;
            }

            note.CompanyId = company;
            note.InvoidId = invoice;
            note.EmployeeId = employee;
            note.StoreCity = city;
            note.OrderDate = date;

            return true;
        }
    }
}
