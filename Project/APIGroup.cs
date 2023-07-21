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

                if (!comps.Any()) return Results.StatusCode(404);

                return Results.Json(comps);
            });

            group.MapPost("/company", async (Company input, AppDBContext db) =>
            {
                db.Companies.Add(input);
                await db.SaveChangesAsync();

                return Results.StatusCode(201);
            });

            group.MapGet("/company/{id}", async (AppDBContext db, int id) =>
            {
                var comp = await db.Companies.FindAsync(id);

                if (comp is null) return Results.StatusCode(404);

                return Results.Json(comp);
            });

            group.MapPut("/company/{id}", async (int id, Company input, AppDBContext db) =>
            {

                var comp = await db.Companies.FindAsync(id);

                if (comp is null) return Results.StatusCode(404);

                comp.Name = input.Name;
                comp.Address = input.Address;
                comp.City = input.City;
                comp.State = input.State;
                comp.Tel = input.Tel;

                await db.SaveChangesAsync();

                return Results.Ok("succcess");
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

            group.MapPost("/employee", async (Employee input, AppDBContext db) =>
            {
                db.Employees.Add(input);
                await db.SaveChangesAsync();

                return Results.StatusCode(201);
            });

            group.MapGet("/employee/{id}", async (AppDBContext db, int id) =>
            {
                var emp = await db.Employees.FindAsync(id);

                if (emp is null) return Results.StatusCode(404);

                return Results.Json(emp);
            });

            group.MapPut("/employee/{id}", async (int id, Employee input, AppDBContext db) =>
            {
                var emp = await db.Employees.FindAsync(id);

                if (emp is null) return Results.StatusCode(404);

                emp.First = input.First;
                emp.Last = input.Last;
                emp.DOB = input.DOB;
                emp.TitleId = input.TitleId;
                emp.PositionId = input.PositionId;

                await db.SaveChangesAsync();

                return Results.Ok("succcess");
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

            group.MapPost("/note", async (Note input, AppDBContext db) =>
            {
                db.Notes.Add(input);
                await db.SaveChangesAsync();

                return Results.StatusCode(201);
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
