pipeline {
  agent any
  triggers {
    cron 'H 0 * * *'
  }
  stages {
    stage('Build') {
      steps {
        bat 'dotnet restore'
        bat 'dotnet build --no-restore'
      }
    }

    stage('Open Notepad') {
      steps {
        bat '''
          set JENKINS_NODE_COOKIE=dontKillMe
          start "" C:\\temp\\Back.bat
        '''
      }
    }
  }
}
