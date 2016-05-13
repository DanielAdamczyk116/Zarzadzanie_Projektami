using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Zarzadzanie_Projektami.Models;

namespace Zarzadzanie_Projektami.DAL
{
    public class ProjektInitializer: DropCreateDatabaseIfModelChanges<ProjektContext>
    {
        protected override void Seed(ProjektContext context)
        {

            var profile = new List<Profil>
            {
                new Profil { Imie="Daniel", Login="Danda",Nazwisko="Adamczyk", DataUtworzeniaKonta=DateTime.Today,}
            };
            profile.ForEach(p => context.Profil.Add(p));
            context.SaveChanges();

            var projekty = new List<Projekt>
            {
                new Projekt { Nazwa="Strona internetowa", Opis="Utworzenie prostej strony dla sklepu internetowego o tematyce samochodowej", Profil=profile[0]    }
            };
            projekty.ForEach(p => context.Projekt.Add(p));
            context.SaveChanges();

            var zadania = new List<Zadanie>
            {
                new Zadanie { Nazwa="Utworzenie GUI", CzasTrwania=100, Znaczenie=ZadanieEnum.Niekrytyczne, Projekt = projekty[0] }
            };
            zadania.ForEach(p => context.Zadanie.Add(p));
            context.SaveChanges();

            var zasoby = new List<Zasob>
            {
                new Zasob { Nazwa="Grafik" , Rodzaj=ZasobEnum.Pracownik, Zadanie = zadania[0] },
                new Zasob { Nazwa="JAVA MVC", Rodzaj=ZasobEnum.Narzędzie, Zadanie = zadania[0] }
            };
            zasoby.ForEach(p => context.Zasob.Add(p));
            context.SaveChanges();


            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ProjektContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ProjektContext()));

            roleManager.Create(new IdentityRole("Admin"));

            var user = new ApplicationUser { UserName = "kewar116@o2.pl" };
            string passwor = "Danielczyk116!";

            userManager.Create(user, passwor);

            userManager.AddToRole(user.Id, "Admin");

           
        }
    }
}