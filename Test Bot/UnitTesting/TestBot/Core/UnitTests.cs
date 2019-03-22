using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace TestBot.Core
{
    public class UnitTests : ModuleBase<SocketCommandContext>
    {
        bool[] tests = { true, true, true };

        [Command(".Test")]
        public async Task Test1() => await ReplyAsync(".Greetings");

        [Command("Oh hey there!")]
        public async Task Test2()
        {
            await ReplyAsync(".Echo testMessage");
            tests[0] = true;
        }

        [Command("testMessage")]
        public async Task Test3()
        {             
            await ReplyAsync(".CreateTask TestTask~TestDeveloper~TestDescription");
            tests[1] = true;
        }

        [Command("Task: 'TestTask', Developer: 'TestDeveloper', Description: 'TestDescription'.")]
        public async Task Test4()
        {
            tests[2] = true;
        }

        [Command(".TestResults")]
        public async Task TestResults()
        {
            if (tests[0] == true) await ReplyAsync("_TEST 1_: PASSED");
            if (tests[0] == false) await ReplyAsync("_TEST 1_: FAILED");
            if (tests[1] == true) await ReplyAsync("_TEST 2_: PASSED");
            if (tests[1] == false) await ReplyAsync("_TEST 2_: FAILED");
            if (tests[2] == true) await ReplyAsync("_TEST 3_: PASSED");
            if (tests[2] == false) await ReplyAsync("_TEST 3_: FAILED");
        }
    }
}
