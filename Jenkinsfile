pipeline {
  agent any
  triggers {
    cron '* * * * *'
  }
  stages {
    stage('Build') {
      steps {
        bat 'dotnet restore'
        bat 'dotnet build --no-restore'
      }
    }

    stage('Run Batch File') {
      steps {
        bat 'call C:\\temp\\Back.bat'
      }
    }
  }
}
