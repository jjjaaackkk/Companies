using Companies.Models;
using Microsoft.EntityFrameworkCore;

namespace Companies
{
    public static class APIGroup
    {
        public static RouteGroupBuilder MapAPI(this RouteGroupBuilder group)
        {
            group.MapGet("/companies", async (AppDBContext db) =>
            {
                var comps = await db.Companies.ToListAsync();

                if (!comps.Any()) return Results.Text("empty");

                return Results.Json(comps);
            });

            group.MapPost("/company", async (context) =>
            {
                var form = context.Request.Form;
                var ser = new Serializator(form);

                var comp = new Company();
                var result = "";

                if (!ser.Parse(ref comp))
                {
                    context.Response.StatusCode = 400;
                    result = ser.Error;
                }
                else
                {
                    var db = context.RequestServices.GetService<AppDBContext>();
                    db.Add(comp);
                    await db.SaveChangesAsync();
                    context.Response.StatusCode = 201;
                    result = "success";
                }

                await context.Response.WriteAsync(result);
            });

            group.MapGet("/company/{id}", async (AppDBContext db, int id) =>
            {
                var comp = await db.Companies.FindAsync(id);

                if (comp is null) return Results.StatusCode(202);

                return Results.Json(comp);
            });

            group.MapPut("/company/{id}", async (context) =>
            {
                var _id = context.Request.Path.ToString().Split('/')[4];
                var id = 0;
                int.TryParse(_id, out id);

                var form = context.Request.Form;
                var ser = new Serializator(form);

                var input = new Company();
                var result = "";

                if (id == 0)
                {
                    result = "no id!";
                }
                else if (!ser.Parse(ref input))
                {
                    context.Response.StatusCode = 400;
                    result = ser.Error;
                }
                else
                {
                    var db = context.RequestServices.GetService<AppDBContext>();
                    var comp = await db.Companies.FindAsync(id);

                    if (comp == null)
                    {
                        context.Response.StatusCode = 404;
                        result = "not found";
                    }
                    else
                    {
                        comp.Name = input.Name;
                        comp.Address = input.Address;
                        comp.City = input.City;
                        comp.State = input.State.ToUpper();
                        comp.Tel = input.Tel;

                        await db.SaveChangesAsync();
                        result = "success";
                    }
                }

                await context.Response.WriteAsync(result);
            });

            group.MapGet("/company/{id}/employees", async (AppDBContext db, int id) =>
            {
                var emps = await db.Employees.Where(e => e.CompanyId == id).ToListAsync();

                if (!emps.Any()) return Results.StatusCode(404);

                return Results.Json(emps);
            });

            group.MapGet("/company/{id}/notes", async (AppDBContext db, int id) =>
            {
                var notes = await db.Notes.Where(n => n.CompanyId == id).ToListAsync();

                if (!notes.Any()) return Results.StatusCode(404);

                return Results.Json(notes);
            });

            group.MapPost("/employee", async (context) =>
            {
                var form = context.Request.Form;
                var ser = new Serializator(form);

                var emp = new Employee();
                var result = "";

                if (!ser.Parse(ref emp))
                {
                    context.Response.StatusCode = 400;
                    result = ser.Error;
                }
                else
                {
                    var db = context.RequestServices.GetService<AppDBContext>();
                    db.Add(emp);
                    await db.SaveChangesAsync();
                    context.Response.StatusCode = 201;
                    result = "success";
                }

                await context.Response.WriteAsync(result);
            });

            group.MapGet("/employee/{id}", async (AppDBContext db, int id) =>
            {
                var emp = await db.Employees.FindAsync(id);

                if (emp is null) return Results.StatusCode(404);

                return Results.Json(emp);
            });

            group.MapPut("/employee/{id}", async (context) =>
            {
                var _id = context.Request.Path.ToString().Split('/')[4];
                var id = 0;

                int.TryParse(_id, out id);

                var form = context.Request.Form;
                var ser = new Serializator(form);

                var db = context.RequestServices.GetService<AppDBContext>();

                var input = new Employee();
                var result = "";

                if (id == 0)
                {
                    context.Response.StatusCode = 400;
                    result = "invalid id!";
                }
                else if (!ser.Parse(ref input))
                {
                    context.Response.StatusCode = 400;
                    result = ser.Error;
                }
                else
                {
                    var emp = await db.Employees.FindAsync(id);

                    if (emp == null)
                    {
                        context.Response.StatusCode = 404;
                        result = "not found";
                    }
                    else
                    {
                        emp.First = input.First;
                        emp.Last = input.Last;
                        emp.TitleId = input.TitleId;
                        emp.DOB = input.DOB;
                        emp.PositionId = input.PositionId;

                        await db.SaveChangesAsync();
                        result = "success";
                    }
                }

                await context.Response.WriteAsync(result);
            });

            group.MapDelete("/employee/{id}", async (AppDBContext db, int id) =>
            {
                if (await db.Employees.FindAsync(id) is Employee employee)
                {
                    db.Employees.Remove(employee);
                    await db.SaveChangesAsync();
                    return Results.Ok("success");
                }

                return Results.StatusCode(404);
            });

            group.MapPost("/note", async (context) =>
            {
                var form = context.Request.Form;
                var ser = new Serializator(form);

                var note = new Note();
                var result = "";

                if (!ser.Parse(ref note))
                {
                    context.Response.StatusCode = 400;
                    result = ser.Error;
                }
                else
                {
                    var db = context.RequestServices.GetService<AppDBContext>();
                    db.Add(note);
                    await db.SaveChangesAsync();
                    context.Response.StatusCode = 201;
                    result = "success";
                }

                await context.Response.WriteAsync(result);
            });

            group.MapDelete("/note/{id}", async (AppDBContext db, int id) =>
            {
                if (await db.Notes.FindAsync(id) is Note note)
                {
                    db.Notes.Remove(note);
                    await db.SaveChangesAsync();
                    return Results.Ok("success");
                }

                return Results.StatusCode(404);
            });

            group.MapGet("/positions", async (AppDBContext db) =>
            {
                var pos = await db.Positions.ToListAsync();

                if (pos is null) return Results.StatusCode(404);

                return Results.Json(pos);
            });

            group.MapGet("/titles", async (AppDBContext db) =>
            {
                var titles = await db.Titles.ToListAsync();

                if (titles is null) return Results.StatusCode(404);

                return Results.Json(titles);
            });

            return group;
        }
    }
}
