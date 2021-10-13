using System;
using System.Collections.Generic;
using System.Text;

namespace Hours_Tracker
{
    class EntryNode
    {

        public bool isActive { get; private set; }

        DateTime startTime;
        DateTime stopTime;

        TimeSpan time;

        public EntryNode(DateTime start, DateTime stop)
        {
            startTime = start;
            stopTime = stop;
            time = stop-start;
            isActive = false;
        }
        public EntryNode(DateTime start)
        {
            startTime = start;
            isActive = true;
        }

        public void SetStop(DateTime stop)
        {
            stopTime = stop;
            time = stop - startTime;
            isActive = false;
        }

        public TimeSpan GetTime()
        {
            if (stopTime == DateTime.MinValue)
            {
                return DateTime.Now - startTime;
            }

            return time;
        }
        public string GetStartTime()
        {
            return startTime.ToString();
        }

        public string GetStopTime()
        {
            return (isActive) ? "Entry is active, Clock Out to Set Stop Time" : stopTime.ToString();
        }

        public string GetTotalEntryTime()
        {
            return (isActive) ? "Entry is still active" : time.ToString();
        }

        public string GetSaveData(int index)
        {
            string output = "Entry " + index.ToString();
            output += "\nStart Time = \"" + startTime + "\"\n";
            if (!isActive)
                output += "Stop Time = \"" + stopTime + "\"\n";
            return output;
        }
    }
    class Project
    {
        public string projectName { get; private set; }

        string[] projectData;

        List<EntryNode> entries = new List<EntryNode>();

        TimeSpan currentTotalHours;

        EntryNode latestEntry;

        /* Constructors */

        // Project with Entries
        public Project(string name, string[] data)
        {
            this.projectName = name;
            this.projectData = data;

            ParseData();
        }

        // Empty Project
        public Project(string name)
        {
            this.projectName = name;
        }

        private void ParseData()
        {
            for(int i = 0; i < projectData.Length; i++)
            {
                if (projectData[i].Contains("Entry"))
                {
                    EntryNode entry;

                    DateTime start;
                    DateTime stop;

                    if (i + 1 < projectData.Length)
                    {
                        i++;
                        
                        int first = projectData[i].IndexOf("\"") + 1;
                        int last = projectData[i].LastIndexOf("\"");
                        DateTime.TryParse(projectData[i].Substring(first, last - first), out start);
                    }
                    else
                        continue;
                    

                    if (i + 1 < projectData.Length)
                    {
                        i++;

                        int first = projectData[i].IndexOf("\"") + 1;
                        int last = projectData[i].LastIndexOf("\"");
                        DateTime.TryParse(projectData[i].Substring(first, last - first), out stop);
                        entry = new EntryNode(start, stop);
                    }
                    else
                    {
                        entry = new EntryNode(start);
                    }

                    entries.Add(entry);
                    latestEntry = entry;
                }
            }
        }

        public void OpenNewEntry(DateTime start)
        {
            latestEntry = new EntryNode(start);

            entries.Add(latestEntry);
        }

        public void CloseEntry(DateTime stop)
        {
            latestEntry.SetStop(stop);
        }

        public bool IsActive()
        {
            if (latestEntry != null)
                return latestEntry.isActive;

            return false;
        }

        public string GetTotalTime()
        {
            TimeSpan totalTime = new TimeSpan();
            foreach (EntryNode entry in entries)
            {
                totalTime += entry.GetTime();
            }
            return (totalTime.Days * 24 + totalTime.Hours) + " Hours and " + currentTotalHours.Minutes + " Minutes.";

        }

        public string[] GetSaveData()
        {
            string[] output = new string[entries.Count + 2];

            output[0] = "Project = *" + projectName + "*\n";
            for (int i = 1; i < output.Length - 1; i++)
            {
                output[i] = entries[i - 1].GetSaveData(i-1);
            }

            output[output.Length - 1] = "END\n";
            return output;
        }

        public string RenameProject(string name)
        {
            string tempString = projectName;
            projectName = name;
            return tempString;
        }

        public List<EntryNode> GetEntries()
        {
            return entries;
        }
    }
}
