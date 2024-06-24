using System;
using System.Collections.Generic;

namespace FilRouge.Models;

public partial class Liste
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int? ProjetId { get; set; }

    public virtual Projet? Projet { get; set; }

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
