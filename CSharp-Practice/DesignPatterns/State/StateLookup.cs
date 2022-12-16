using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Practice.DesignPatterns.State
{
    public class StateLookup
    {
        public StateLookup(string id, 
            string name, 
            List<string> allowedStates,
            bool canDelete)
        {
            Id = id;
            Name = name;
            AllowedStates = allowedStates;
            CanDelete = canDelete;
        }

        public string Id { get; }
        public string Name { get; }
        public List<string> AllowedStates { get; }
        public bool CanDelete { get; }
    }

    public class StateLookups
    {
        private static string proposed_id = "proposed";
        private static string active_id = "active";
        private static string resolved_id = "resolved";
        private static string closed_id = "closed";
        private static string deleted_id = "deleted";

        public static readonly StateLookup Proposed = new StateLookup(proposed_id, "Proposed", new List<string> { active_id, resolved_id, closed_id }, true);        
        public static readonly StateLookup Active = new StateLookup(active_id, "Active", new List<string>() { proposed_id, resolved_id }, false);        
        public static readonly StateLookup Resolved = new StateLookup(resolved_id, "Resolved", new List<string> { active_id }, false);        
        public static readonly StateLookup Closed = new StateLookup(closed_id, "Closed", new List<string> {  }, true);
        public static readonly StateLookup Deleted = new StateLookup(deleted_id, "Deleted", new List<string> { }, false);
    }
}
