using System.Collections.Generic;
using KhepriBot2.JSONTemplates;
using Newtonsoft.Json;
using System;
using System.Timers;

namespace KhepriBot2 {
    public class KhepriFileStorageManager {

        public KhepriFileStorageManager() {
            LoadUserList();
            LoadSafeStorageList();

            System.Timers.Timer timer = new System.Timers.Timer(TimeSpan.FromMinutes(10).TotalMilliseconds);
            timer.AutoReset = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(SaveAll);
            timer.Start();
        }

        public List<User> UserList { get; private set; }
        public List<SafeStorage> SafeList { get; private set; }

        private void LoadUserList() {
            string userListData = System.IO.File.ReadAllText("JSONFiles/users.json");
            UserList = JsonConvert.DeserializeObject<List<User>>(userListData);
        }

        public void SaveUserList() {
            string userDataToSave = JsonConvert.SerializeObject(UserList);
            System.IO.File.WriteAllText("JSONFiles/users.json", userDataToSave);
            System.Console.WriteLine("UserList has been saved");
        }

        private void LoadSafeStorageList() {
            string safeListData = System.IO.File.ReadAllText("JSONFiles/safestorage.json");
            SafeList = JsonConvert.DeserializeObject<List<SafeStorage>>(safeListData);
        }

        private void SaveSafeStorageList() {
            string safeDataToSave = JsonConvert.SerializeObject(SafeList);
            System.IO.File.WriteAllText("JSONFiles/safestorage.json", safeDataToSave);
            System.Console.WriteLine("SafeStorage has been saved");
        }

        public int AdjustKhepris(string username, int khepris) {
            UserList.Find(mentionedUser => mentionedUser.username.Equals(username)).khepris += khepris;
            AdjustSafeKhepris(UserList.Find(mentionedUser => mentionedUser.username.Equals(username)).safename, khepris);
            return UserList.Find(mentionedUser => mentionedUser.username.Equals(username)).khepris;
        }

        private void AdjustSafeKhepris(string safename, int khepris) {
            SafeList.Find(mentionedUser => mentionedUser.safename.Equals(safename)).khepris += khepris;
        }

        private void SaveAll(object sender, ElapsedEventArgs e) {
            System.Console.WriteLine("Saving UserList and SafeStorage");
            SaveUserList();
            SaveSafeStorageList();
        }
        public void SaveAll() {
            System.Console.WriteLine("Saving UserList and SafeStorage");
            SaveUserList();
            SaveSafeStorageList();
        }
    }
}