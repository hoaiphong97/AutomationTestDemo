pipeline {
    agent any
    stages {
        stage('Build') { 
            steps {
                bat 'dotnet version' 
                bat 'dotnet build --no-restore' 
            }
        }
    }
}
