using System.Collections.Generic;

//combine dialogue + sprite UI 
public class Customer
{
   public string name;
   public string dialogue;
   public int prefab_idx;

   public Customer(string name, string dialogue, int prefab_idx)
   {
      this.name = name;
      this.dialogue = dialogue;
      this.prefab_idx = prefab_idx;
   }
}