using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static int lastCreatedIssueNumber;
        private static long lastCreatedCommentId;
        string repo = "test-nakov-repo";
        int issueNumber = 1;

        [SetUp]
        public void Setup()
        {            
            this.client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "username", "token");
        }


        [Test, Order (1)]
        public void Test_GetAllIssuesFromARepo()
        { 
            var issues = client.GetAllIssues(repo);

            Assert.That(issues.Count, Is.GreaterThan(1), "There Should be more than one issue");

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greeater than 0.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue title should not be empty.");
            }
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            var issue = client.GetIssueByNumber(repo, issueNumber);

            Assert.That(issue, Is.Not.Null, "The response should contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater that 0.");
            Assert.That(issue.Number, Is.EqualTo(issueNumber), "The issue number should match the requested number");
            //Assert.That(issue.Title, Is.EqualTo("Test creation"));
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            Assert.That(labels, Has.Count.GreaterThan(0), "The labels count should be greater than 0.");

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be greater than 0.");
                Assert.That(label.Name, Is.Not.Empty, "Label name should not be empty");

                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");
            }

        }

        [Test, Order (4)]
        public void Test_GetAllCommentsForIssue()
        {
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            Assert.That(comments, Has.Count.GreaterThan(0), "Comments count should be greater than 0.");

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be greater than 0.");
                Assert.That(comment.Body, Is.Not.Empty, "Comment body should not be empty");

                Console.WriteLine($"Comment ID: {comment.Id} - Body: {comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 1000);
            string title = $"Test Title-{randomNumber}";
            string body = $"Test body-{randomNumber}";

            var issue = client.CreateIssue(repo, title, body);

            Assert.Multiple(() =>
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue title should not be empty.");
                Assert.That(issue.Title, Is.EqualTo(title), "The issue title should match the requested title.");
                Assert.That(issue.Body, Is.Not.Empty, "Issue body should not be empty.");
                Assert.That(issue.Body, Is.EqualTo(body), "The issue body should match the requested body.");
            });

            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            string commentBody = "Test Comment";

            var comment = client.CreateCommentOnGitHubIssue(repo, lastCreatedIssueNumber, commentBody);

            Assert.That(comment.Id, Is.GreaterThan(0));
            Assert.That(comment.Body, Is.Not.Empty);
            Assert.That(comment.Body, Is.EqualTo(commentBody));

            lastCreatedCommentId = comment.Id;
        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            var comment = client.GetCommentById(repo, lastCreatedCommentId);

            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(lastCreatedCommentId));
            Assert.That(comment.Body, Is.EqualTo("Test Comment"));
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            string updatedBody = "Edited Test Comment";

            var updatedComment = client.EditCommentOnGitHubIssue(repo, lastCreatedCommentId, updatedBody);

            Assert.That(updatedComment.Id, Is.GreaterThan(0));
            Assert.That(updatedComment.Body, Is.Not.Empty);
            Assert.That(updatedComment.Body, Is.EqualTo(updatedBody));
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            bool result = client.DeleteCommentOnGitHubIssue(repo, lastCreatedCommentId);

            Assert.That(result, Is.True);
        }

        [Test, Order (10)]
        public void Test_CloseIssueOnGitHub()
        {
            bool result = client.CloseIssueOnGitHub(repo, lastCreatedIssueNumber);

            Assert.That(result, Is.True);   
        }
    }
}

