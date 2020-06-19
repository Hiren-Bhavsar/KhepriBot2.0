using System.Collections.Generic;
using KhepriBot2.JSONTemplates;

namespace KhepriBot2 {
    public class KhepriFileStorageManager {
        public List<User> GetUserList() {
            string _userListData = System.IO.File.ReadAllText("JSONFilesusers.json");
            var _userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(_userListData);
            return _userList;
        }

        public void SaveUserList(List<User> _userList) {
            //TODO
        }

        public List<SafeStorage> GetSafeStorageList() {
            string _safeListData = System.IO.File.ReadAllText("safestorage.json");
            var _safeList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SafeStorage>>(_safeListData);
            return _safeList;
        }

        private void SaveSafeStorageList(List<SafeStorage> _safeList) {
            //TODO
        }
    }
}