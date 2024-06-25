using System;
using System.Collections.Generic;

namespace FilRouge.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public string Contenu { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public int? TacheId { get; set; }

    public virtual Tache? Tache { get; set; }
}
