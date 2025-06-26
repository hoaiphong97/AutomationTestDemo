pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                // Command to build your WPF application
                bat 'dotnet /p:Configuration=Release WpfAppDemo.sln'
            }
        }
        stage('Test') {
            steps {
                // Command to run tests for your WPF application
                bat 'dotnet test WpfAppDemo.Tests/WpfAppDemo.Tests.csproj'
            }
        }
        stage('Deploy') {
            steps {
                // Command to deploy your WPF application
                bat 'deploy.bat'
            }
        }
    }
}
