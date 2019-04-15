using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Discord;
using Discord.Commands;

using ScrumBot;

namespace TestBot
{
  [TestClass()]
  public class UnitTests
  {
    [TestMethod]
    public void CreateFileWithTitleTest()
    {
      string filename = "testFile1";
      string title = "testTitle";

      ReadAndWrite rw = new ReadAndWrite();
      rw.CreateFileWithTitle(filename, title);

      Assert.IsTrue(File.Exists(filename));
    }

    [TestMethod]
    public void DeleteFileTest()
    {
      string filename = "testFile2";

      ReadAndWrite rw = new ReadAndWrite();
      rw.CreateFileWithTitle(filename, "");

      if (File.Exists(filename))
      {
        rw.deleteFile(filename);
        Assert.IsFalse(File.Exists(filename));
      } else {
        Assert.Fail();
      }
    }

    [TestMethod]
    public void EditReadSectionTest()
    {
      string filename = "testFile3";

      ReadAndWrite rw = new ReadAndWrite();
      rw.CreateFileWithTitle(filename, "testSection");
      rw.EditSection(filename, "testSection", "newText");

      Assert.AreEqual("testSection" + "\r\n---\r\n" + "newText", rw.ReadSection(filename, "testSection"));
    }
  }
}
