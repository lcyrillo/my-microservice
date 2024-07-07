
using AutoFixture;

namespace MyMicroservice.Data;

public static class Seeder
{
    public static void Seed(this MicroDbContext microDbContext)
    {
        if (!microDbContext.Persons.Any())
        {
            Fixture fixture = new Fixture();
            fixture.Customize<Persons>(person => person.Without(p => p.Id));

            List<Persons> persons = fixture.CreateMany<Persons>(100).ToList();
            microDbContext.AddRange(persons);
            microDbContext.SaveChanges();
        }
    }
}