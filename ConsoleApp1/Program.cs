// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;



/* TP 4 Héritage */

using System;

/*class Compte
{
    private static int compteCounter = 0;
    protected int codeCompte;
    protected string titulaire;
    protected double solde;
    
    public int CodeCompte
    {
        get { return codeCompte; }
    }

    public string Titulaire
    {
        get { return titulaire;  }
    }

    public double Solde
    {
        get { return solde; }
    }

    public Compte(string titulaire)
    {
        codeCompte = ++compteCounter;
        this.titulaire = titulaire;
        solde = 0;
    }
    
    public Compte(string titulaire, double soldeInitial)
    {
        codeCompte = ++compteCounter;
        this.titulaire = titulaire;
        solde = soldeInitial;
    }

    public void Deposer(double montant)
    {
        if (montant > 0)
        {
            solde += montant;
        }
    }
    
    public void Retirer(double montant)
    {
        if (montant > 0 && montant <= solde)
        {
            solde -= montant;
        }
    }

    public override string ToString()
    {
        return $"Code: {codeCompte}, Titulaire: {titulaire}, Solde: {solde}";
    }

    public bool Equals(Compte autreCompte)
    {
        return codeCompte == autreCompte.codeCompte;
    }
}

class CompteEpargne : Compte
{
    public double TauxInteret { get; }
    
    public CompteEpargne(string titulaire, double tauxInteret) : base(titulaire)
    {
        TauxInteret = tauxInteret;
    }
    
    public void CalculerInteret()
    {
        double interet = solde * TauxInteret / 100;
        Deposer(interet);
    }
}

class ComptePayant : Compte
{
    public double Commission { get; }
    
    public ComptePayant(string titulaire, double commission) : base(titulaire)
    {
        Commission = commission;
    }

    public new void Retirer(double montant)
    {
        base.Retirer(montant + Commission);
    }
}

class Program
{
    static void Main()
    {
        Compte compte = new Compte("BOUFAARA Oussama");
        CompteEpargne compteEpargne = new CompteEpargne("BOUFAARA Oussama", 5);
        ComptePayant comptePayant = new ComptePayant("BOUFAARA Oussama", 2);
        
        compte.Deposer(1000);
        compte.Retirer(500);
        
        compteEpargne.Deposer(1500);
        compteEpargne.CalculerInteret();
        
        comptePayant.Deposer(2000);
        comptePayant.Retirer(300);
        
        Console.WriteLine("Compte:");
        Console.WriteLine(compte.ToString());
        
        Console.WriteLine("Compte Epargne:");
        Console.WriteLine(compteEpargne.ToString());
        
        Console.WriteLine("Compte Payant:");
        Console.WriteLine(comptePayant.ToString());
    }
} */

/*Tp_5 */

public abstract class Employe
{
    private static int matriculeInc = 0;
    public int Matricule { get; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public DateTime DateNaissance { get; set; }
    
    public Employe(string Nom,string Prenom,DateTime DateNaissance)
    {
        this.Matricule = ++matriculeInc;
        this.Nom = Nom;
        this.Prenom = Prenom;
        this.DateNaissance = DateNaissance;
    }
    
    public abstract double CalculSalaire();

    public override string ToString()
    {
        return $"Marticule: {Matricule}, Nom: {Nom}, Prenom: {Prenom}, Date de naissance: {DateNaissance}";
    }
}

public class Ouvrier : Employe
{
    private const double SMIG = 2500;
    public DateTime DateEntree { get; set; }
    
    public Ouvrier(string Nom, string Prenom, DateTime DateNaissance, DateTime DateEntree) : base(Nom, Prenom, DateNaissance)
    {
        this.DateEntree = DateEntree;
    }
    public override double CalculSalaire()
    {
        int anciennete = DateTime.Now.Year - DateEntree.Year;
        double salaire = SMIG + ( anciennete * 100 );
        return Math.Min(salaire, SMIG * 2);
    }
    public override string ToString()
    {
        return base.ToString() + $", Date d'entree: {DateEntree}";
    }
    
}

public class Cadre : Employe
{
    public int Indice { get; set; }
    public Cadre(string nom,string prenom,DateTime dateNaissance,int indice) : base(nom,prenom,dateNaissance)
    {
        this.Indice = indice;
    }
    
    public override double CalculSalaire()
    {
        double[] salaires = {13000,15000,17000,20000};
        if (Indice >=1 && Indice <=4)
        {
            return salaires[Indice - 1];
        }
        return 0;
    }

    public override string ToString()
    {
        return base.ToString() + $", Indice: {Indice}";
    }
}

public class Patron : Employe
{
    private const double CA = 10000000;
    public double Pourcentage { get; set; }
    
    public Patron(string nom,string prenom,DateTime dateNaissance,double pourcentage) : base(nom,prenom,dateNaissance)
    {
        this.Pourcentage = pourcentage;
    }

    public override double CalculSalaire()
    {
        return (CA * Pourcentage) / 100;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Pourcentage: {Pourcentage}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employe> employes = new List<Employe>
        {
            new Ouvrier("John","Doe",new DateTime(1980, 5, 15),new DateTime(2000, 3, 10)),
            new Cadre("Alice","Smith",new DateTime(1985, 8, 20),2),
            new Patron("Bob","Johnson",new DateTime(1970, 10, 5),5)
        };

        foreach (Employe employe in employes)
        {
            Console.WriteLine(employe);
            Console.WriteLine($"Salaire: {employe.CalculSalaire()} DH");
            Console.WriteLine();
        }
    }
}