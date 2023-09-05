[Terraform]
主要檔案: terrafform.tf、account.json
連結GCP帳號專案，用設定VM所需規格(機器硬體規格、防火牆、VPC設定)


[ansible]
主要檔案: playbook.yml、/role內相關檔案、hosts、vars.yml、ansible.cfg
主要用途: 以Ansible連動GCP&Gitlab創建所需的功能(pip、docker、Jenkins、Gitlab)

1. docker: 建置docker，以便開起Container
2. Gitlab: 存放目前所有檔案並進行版控
3. Jenkins: 建置用來進行CICD功能(在此會設定兩條pipeLine  Create VM & ansible)
   - Create VM: 設定 Jenkins Job，從gitLab上Clone檔案，並執行Terraform相關檔案進行VM的建置
   - Ansible: 設定 Jenkins Job，執行ansible功能，在此進行安裝nginx、build Docker image、複製&設定簡易網頁


[Jenkinsfile]
主要檔案: createVM.grovy、ansibleTest.grovy

createVM.grovy: 用來設定上述 Create VM 的 Jenkins Job
ansibleTest.grovy: 用來設定上述 Ansible 的 Jenkins Job

[Docker]
主要用途: 一些Docker的相關練習與資料

[AnsibleCreateVM]
主要用途: 練習使用Ansible呼叫Terrafotm

[BeginForCICD]
同 [ansible]，配合[AnsibleCreateVM]先再另一台VM架設 Jenkins & Gitlab，以方便熟練CICD流程