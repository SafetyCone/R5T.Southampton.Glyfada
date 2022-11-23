using System;

using R5T.Glyfada;using R5T.T0064;


namespace R5T.Southampton.Glyfada
{[ServiceImplementationMarker]
    public class GitSourceControlOperator : ISourceControlOperator,IServiceImplementation
    {
        private IGitOperator GitOperator { get; }


        public GitSourceControlOperator(IGitOperator gitOperator)
        {
            this.GitOperator = gitOperator;
        }

        public void Add(string path)
        {
            this.GitOperator.Add(path);
        }

        public void Checkout(string repositoryUrl, string localDirectoryPath, string username, string password)
        {
            this.GitOperator.Clone(repositoryUrl, localDirectoryPath);
        }

        public void CommitToRemote(string path, string message)
        {
            this.GitOperator.Commit(path, message);
            this.GitOperator.Push(path);
        }

        public bool IsUnderSourceControl(string path)
        {
            throw new NotImplementedException();   
        }

        public string GetRepositoryRootDirectoryPath(string path)
        {
            throw new NotImplementedException();
        }

        public void Update(string path)
        {
            this.GitOperator.Fetch(path);
            this.GitOperator.Pull(path);
        }

        public string GetRemoteRepositoryUrl(string path)
        {
            var remoteRepositoryUrl = this.GitOperator.GetRemoteRepositoryUrl(path);
            return remoteRepositoryUrl;
        }

        public SourceControlOperatorInformation GetOperatorInformation()
        {
            throw new NotImplementedException();
        }
    }
}
