pipeline {
  agent any

  environment {
    ZIP_PATH = 'C:\\temp\\demo.zip'
    EXTRACT_PATH = 'C:\\temp\\demo_extracted'
    BAT_FILE = 'C:\\temp\\demo_extracted\\Back.bat'
  }

  stages {
    stage('Build') {
      steps {
        bat 'dotnet restore'
        bat 'dotnet build --no-restore'
      }
    }

    stage('Unzip Batch File') {
      steps {
        bat """
        powershell -Command "if (Test-Path '${EXTRACT_PATH}') { Remove-Item -Recurse -Force '${EXTRACT_PATH}' }"
        powershell -Command "Expand-Archive -Path '${ZIP_PATH}' -DestinationPath '${EXTRACT_PATH}' -Force"
        """
      }
    }

    stage('Run Batch File') {
      steps {
        bat """
        cd ${EXTRACT_PATH}
        call Back.bat
        """
      }
    }
    stage('Publish MSTest Results') {
      steps {
        mstest testResultsFile: '"C:\temp\*.trx"'
      }
    }
  }

  post {
    success {
      echo '✅ Pipeline completed successfully.'
    }
    failure {
      echo '❌ Something went wrong. Please check the logs.'
    }
  }
}
