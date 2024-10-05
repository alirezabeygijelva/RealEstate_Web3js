using System;
using System.Collections.Generic;
using System.Text;

namespace MyRealEstate.Services.Services
{
    public class ContractInfo
    {
        public string AccountAddress = "";
        public string AccountPassword = "";
        public string AcontractAddress = "0x845ABbe5D3C8D6D2D0299EAF5a0FcA5c2C35cCC1";
        public string AcontractAbi = @"[{""constant"": false,""inputs"": [{""name"": ""ecCode"",""type"": ""uint256""}],""name"": ""accept"",""outputs"": [{""name"": """",""type"": ""bool""}],""payable"": false,""stateMutability"": ""nonpayable"",""type"": ""function""},{""constant"": false,""inputs"": [{""name"": ""ecCode"",""type"": ""uint256""},{""name"": ""buyer"",""type"": ""address""},{""name"": ""seller"",""type"": ""address""},{""name"": ""amount"",""type"": ""uint256""}],""name"": ""addEstateContract"",""outputs"": [{""name"": """",""type"": ""bool""}],""payable"": false,""stateMutability"": ""nonpayable"",""type"": ""function""},{""constant"": false,""inputs"": [{""name"": ""sender"",""type"": ""address""},{""name"": ""receiver"",""type"": ""address""},{""name"": ""transferAmount"",""type"": ""uint256""}],""name"": ""transferFrom"",""outputs"": [{""name"": """",""type"": ""bool""}],""payable"": false,""stateMutability"": ""nonpayable"",""type"": ""function""},{""inputs"": [],""payable"": true,""stateMutability"": ""payable"",""type"": ""constructor""},{""constant"": true,""inputs"": [{""name"": ""accountToCheck"",""type"": ""address""}],""name"": ""customerExist"",""outputs"": [{""name"": """",""type"": ""bool""}],""payable"": false,""stateMutability"": ""view"",""type"": ""function""},{""constant"": true,""inputs"": [{""name"": """",""type"": ""uint256""}],""name"": ""EsContractStrsCodes"",""outputs"": [{""name"": """",""type"": ""uint256""}],""payable"": false,""stateMutability"": ""view"",""type"": ""function""},{""constant"": true,""inputs"": [{""name"": ""tokenOwner"",""type"": ""address""}],""name"": ""getBalance"",""outputs"": [{""name"": """",""type"": ""uint256""}],""payable"": false,""stateMutability"": ""view"",""type"": ""function""},{""constant"": true,""inputs"": [{""name"": ""ecCode"",""type"": ""uint256""}],""name"": ""getOwner"",""outputs"": [{""name"": ""owner"",""type"": ""address""}],""payable"": false,""stateMutability"": ""view"",""type"": ""function""}]";
        public string AcontractName = "RealEstateToken";
    }
}
