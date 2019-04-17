# Azure DevOps / AKS Workshop

## About Me

Hi, 

My name is Maciej Misztal and I'm the author of this workshop. I've been working with Azure ever since 2011, and have been working  the changes which have occured over the years. 

You can follow me on:
- [Twitter](https://twitter.com/mmisztal1980)
- [LinkedIn](https://www.linkedin.com/in/maciej-misztal-bb424221/)

## Azure Access

During the workshop, you will be given a set of credentials, that you will use to sign into Azure, Azure DevOps and MS Teams.

> **Payment Card**
>
> A Credit or Debit Card will be required to activate your trial Azure subscription. Please note that **you will not** be charged.

## About the workshop

### General Information
The workshop was originally created for [Azure Day Poland 2019](http://azureday.pro/#/) pre-conf workshops, but it aims to repeatadly deliver the content to other audiences.

> **Warning**
>
> The scope of the workshop might change. Please check this page for updates

This workshop aims to deliver hand-on experience for people wanting to start their adventure with:

- Azure
- Azure DevOps
- AKS (Kubernetes)

### Duration

The workshop is designed to take 6 hrs, however this may take longer depending on the group.

> **Note**
>
> - The workshop aims to deliver 90% of the content in a ready to plug & play state to save time
> - Your instructor is here to answer any questions you  might be having, so don't be afraid to ask

### Required Experience

> **Required experience**
>
> - Ability to use git

> **Nice-to-have experience**
>
> You are **not** expected to have any prior experience with the following technologies, however it's nice to have, as you will be interacting with them during the workshop:
>
> - Azure
> - Azure DevOps
> - Azure CLI
> - ARM Templates
> - Docker
> - kubectl
> - Helm
> - .NET Core

Thoughout the workshop you will be conducting exercises with increasing level of difficulty, with the end-goal of setting up a complete 
continuous delivery pipeline for a set of interconnected microservices.

### Scope
During the workshop, you will:

- Learn how to configure branch policies with pull requests
- Learn how to configure builds & releases
- Learn how to provision [AKS](https://azure.microsoft.com/en-us/services/kubernetes-service/) & [ACR](https://azure.microsoft.com/en-us/services/container-registry/) on Azure
- Learn how to push docker container images to ACR
- Learn how to execute kubernetes deployments using images from the ACR using Azure DevOps
- Learn how to execute kubernetes rolling upgrades using kubernetes manifests
- Learn how to execute kubernetes blue-green deployments using HELM & an ingress controller ([traefik](https://traefik.io/))
- Learn how to handle failing deployments while maintaining 100% application uptime
- Learn how to create complex release pipelines

## Prequisites

### Hardware Requirements

> **Minimum Requirements**
> - CPU with at least 2 cores
> - 4 GB RAM

> **Recommended Requirements**
>
> - CPU with at least 4 physical cores
> - At least 8 GB RAM (16 GB Recommended)

### Software Requirements

The workshop content is implemented on an array of cross-platform technolgies, therefore it is possible to run it on:

- Windows 10
- Mac OS X
- Linux

In order to participate in the workshop, the following software packages are **required**

> **git**
>
> - [Installation instructions](https://git-scm.com/)

> **Cmder** (Windows only)
>
> For the purpose of the workshop it is recommended to use a console, capable of supporting bash & ssh
> - [Installation instructions](https://cmder.net/)

> **Docker CE**
>
> To run the workshop content locally, Docker CE is required.
>
> **Windows**
> - [Installation instructions](https://docs.docker.com/docker-for-windows/install/) (Hyper-V Required)
> - The workshop content is running on linux-based containers. Do not switch to Windows containers
> - Ensure that Kubernetes is enabled
>
> **Mac OS X**
>
> - [Installation instructions](https://docs.docker.com/docker-for-mac/install/)
> - Ensure that Kubernetes is enabled
>
> **Linux**
>
> - Installation instructions
>   - [Ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/)
>   - [CentOS](https://docs.docker.com/install/linux/docker-ce/centos/)
>   - [Debian](https://docs.docker.com/install/linux/docker-ce/debian/)
>   - [Fedora](https://docs.docker.com/install/linux/docker-ce/centos/)
>
> Alternatively
> - [get.docker.com](https://get.docker.com/) installation script
>
> Finally
> - [There is no Kubernetes support for Linux-based Docker CE](https://forums.docker.com/t/is-there-a-built-in-kubernetes-in-docker-ce-for-linux/54374)
> - You can try to use [MicroK8s](https://microk8s.io/) but it hasn't been tested.

> **kubectl**
>
> - [Installation instructions](https://kubernetes.io/docs/tasks/tools/install-kubectl/)

> **helm (client only)**
>
> - [Installation instructions](https://helm.sh/docs/using_helm/#installing-helm)
>
> **note**
> - Windows users might need to install the [chocolatey](https://chocolatey.org/docs/installation) package manager

> **Azure CLI**
>
> - [Installation instructions](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)


> **Text Editor**
>
> VS Code is highly recommended as a cross-platform lightweight text editor / IDE.
> - [Installation instructions](https://code.visualstudio.com/)
>
> The following extesions will make your experience more enjoyable:
> - vscode-icons
> - C#
> - Docker
> - Kubernetes
> - Powershell
> - YAML
> - vscode-helm

### Required reading

> **Warning**
>
> You are expected to have familiarized yourself with the topics listed in this paragraph.

During the workshop you will receive additional materials.

#### General

- [Continuous Integration](https://www.thoughtworks.com/continuous-integration)
- [Continuous Delivery](https://www.thoughtworks.com/continuous-delivery)

#### ASP.NET Core

- [ASP.NET Core Fundamentals](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-2.2&tabs=windows)

#### Docker

- [Docker tutorial](https://www.youtube.com/watch?v=VlSW-tztsvM)

#### Kubernetes
- [Kubernetes - bootcamp](https://kubernetesbootcamp.github.io/kubernetes-bootcamp/)
- [Kubernetes - an overview](https://thenewstack.io/kubernetes-an-overview/)
- [Illustrated children's guide to Kubernetes](https://www.youtube.com/watch?v=4ht22ReBjno)