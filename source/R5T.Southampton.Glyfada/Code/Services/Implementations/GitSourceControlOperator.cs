using System;

using R5T.Glyfada;


namespace R5T.Southampton.Glyfada
{
    public class GitSourceControlOperator : ISourceControlOperator
    {
        private IGitOperator GitOperator { get; }


        public GitSourceControlOperator(IGitOperator gitOperator)
        {
            this.GitOperator = gitOperator;
        }

        public void Add(string localPath)
        {
            this.GitOperator.Add(localPath);
        }

        public void Checkout(string repositoryUrl, string localDirectoryPath)
        {
            this.GitOperator.Clone(repositoryUrl, localDirectoryPath);
        }

        public void CommitToRemote(string localPath, string message)
        {
            this.GitOperator.Commit(localPath, message);
            this.GitOperator.Push(localPath);
        }
    }
}
