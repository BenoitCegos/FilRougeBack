using System;
using System.Collections.Generic;

namespace FilRouge.Models;

public partial class Tache
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? ListeId { get; set; }

    public virtual ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

    public virtual Liste? Liste { get; set; }
}
