///  
/// Author:    Katherine Jang
/// Partner:   None 
/// Date:      20/9/2025
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework. 
/// 
/// I, Katherine Jang , certify that I wrote this code from scratch and did not copy it in part or whole from
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// File Contents 
/// 
/// This file contains the implementation of the DependencyGrapn class, which is designed to 
/// manage the dependence of variables required for calculation. The class includes a dependents and dependees
/// which contains the list of dependents and dependees and provides mothdos which performs
/// adding, removing, and replacing dependencies of Graph.
/// 

using System.Collections;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace SpreadsheetUtilities
{
    /// <summary>
    /// class for manage the dependence of variable required for sheet calculation.
    /// the class includes a dependents dictionary and a dependees dictionary 
    /// and provides methods which performs adding, removeing, and replacing dependencies of Graph.
    /// </summary>
    public class DependencyGraph
    {

        ///<summary>
        /// Dictionary which contains dependents with key dependee
        /// </summary>
        private Dictionary<string, HashSet<string>> dependents;
        ///<summary>
        /// Dictionary which contains dependees with key dependent
        /// </summary>
        private Dictionary<string, HashSet<string>> dependees;
        /// size of dependencies
        private int size;


        /// <summary>
        ///  Constructor of Dependency Graph.
        ///  allocate memory for dependents and dependees and set the size to initial value 0.
        /// </summary>
        public DependencyGraph()
        {
            dependents = new Dictionary<string, HashSet<string>>();
            dependees = new Dictionary<string, HashSet<string>>();

            size = 0;
        }

        /// <summary>
        /// Property for variable => size.
        /// set the size of dependency and returns the size of dependency
        /// </summary>
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int this[string str]
        {
            get
            {
                if (dependees.ContainsKey(str))
                    return dependees[str].Count;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Determine wheter the dependees with key dependee is empty
        /// </summary>
        /// <param name="dependee">key</param>
        /// <returns>
        /// contains -> <c>true</c>
        /// not contains -> <c>false</c>
        /// </returns>
        /// <exception cref="ArgumentException">param can't be null</exception>
        public bool HasDependees(string dependee)
        {
            if (dependee == null)
                throw new ArgumentException("Invalid Argument");
            if (dependees.ContainsKey(dependee) && dependees[dependee].Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// Determine wheter the dependents with key dependent is empty
        /// </summary>
        /// <param name="dependent">key</param>
        /// <returns>
        /// contains -> <c>true</c>
        /// not contains -> <c>false</c>
        /// </returns>
        /// <exception cref="ArgumentException">param can't be null</exception>
        public bool HasDependents(string dependent)
        {
            if (dependent == null)
                throw new ArgumentException("Invalid Argument");
            if (dependents.ContainsKey(dependent) && dependents[dependent].Count > 0)
                return true;

            return false;
        }

        /// <summary>
        /// add pair of dependency : "dependent" dependens on "dependee"
        /// </summary>
        /// <param name="dependee">dependee must be evaluated first</param>
        /// <param name="dependent">dependent must be evalued after dependee is evaluated</param>
        /// <exception cref="ArgumentException">dependent and dependee can't be null</exception>
        public void AddDependency(string dependent, string dependee)
        {
            if (dependent == null || dependee == null)
            {
                string argument = dependent == null ? "dependent" : "dependee";
                throw new ArgumentException("Invalid Argument", argument);
            }

            dependents.TryAdd(dependent, new HashSet<string>());
            dependees.TryAdd(dependee, new HashSet<string>());

            if (dependents[dependent].Add(dependee))
            {
                dependees[dependee].Add(dependent);
                size++;
            }
        }

        /// <summary>
        ///  Remove the pair of dependent and dependee from dependency graph.
        /// </summary>
        /// <param name="dependee">dependee must be evaluated first</param>
        /// <param name="dependent">dependent must be evaluated after dependee is evaluated</param>
        /// <exception cref="ArgumentException">dependent and dependee can't be null</exception>
        public void RemoveDependency(string dependent, string dependee)
        {
            if (dependent == null || dependee == null)
            {
                string argument = dependent == null ? "dependent" : "dependee";
                throw new ArgumentException("Invalid Argument", argument);
            }

            if (!dependents.ContainsKey(dependent) || dependents.Count == 0)
                return;
            dependents[dependent].Remove(dependee);
            if (!dependees.ContainsKey(dependee) || dependees.Count == 0)
                return;
            dependees[dependee].Remove(dependent);

            size--;

            if (dependents[dependent].Count == 0)
                dependents.Remove(dependent);
            if (dependees[dependee].Count == 0)
                dependees.Remove(dependee);
        }

        /// <summary>
        ///  return dependees with specific key "dependee"
        /// </summary> 
        /// <param name="dependee">key for dependees</param>
        /// <returns>IEnumerable dependees </returns>
        public IEnumerable<string> GetDependees(string dependee)
        {
            if (!dependees.ContainsKey(dependee))
            {
                return new HashSet<string>();
            }
            return dependees[dependee];
        }

        /// <summary>
        /// return dependents with specific key "dependent"
        /// </summary>
        /// <param name="dependent">key for dependents</param>
        /// <returns>IEnumrable dependents</returns>
        public IEnumerable<string> GetDependents(string dependent)
        {
            if (!dependents.ContainsKey(dependent))
            {
                return new HashSet<string>();
            }
            return dependents[dependent];
        }

        /// <summary>
        /// repelace the exsiting dependents of the given dependee with new dependents
        /// remove all node that depend on "dependee"
        /// </summary>
        /// <param name="dependee">the specific key which values(dependets) are being replaced</param>
        /// <param name="NewDependents">the new dependents that will depend on the dependee</param>
        public void ReplaceDependents(string dependee, IEnumerable<string> NewDependents)
        {
            if (dependents.ContainsKey(dependee))
            //     dependees.TryAdd(dependee, new HashSet<string>(NewDependents));
            // else
            {
                HashSet<string> OriginalDependents = new HashSet<string>(GetDependents(dependee));

                foreach (var dependent in OriginalDependents)
                    RemoveDependency(dependee, dependent);
            }

            foreach (var dependent in NewDependents)
            {
                AddDependency(dependee, dependent);
            }
        }

        /// <summary>
        /// repelace the exsiting dependees of the given dependent with new dependees
        /// remove all node that is depended by "dependent"
        /// </summary>
        /// <param name="dependent">the specific key which values(dependees) are being replaced</param>
        /// <param name="NewDependents">the new dependees that will be depended on the dependent</param>
        public void ReplaceDependees(string dependent, IEnumerable<string> NewDependees)
        {
            if (dependees.ContainsKey(dependent))
            {
                HashSet<string> OriginalDependees = new HashSet<string>(GetDependees(dependent));

                foreach (var dependee in OriginalDependees)
                    RemoveDependency(dependee, dependent);
                // dependents[dependent] = new HashSet<string>(NewDependees);
            }

            foreach (var dependee in NewDependees)
            {
                // dependees[dependee].Add(dependent);
                AddDependency(dependee, dependent);

            }
        }



    }
}
