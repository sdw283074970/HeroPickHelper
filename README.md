英雄选择助手HeroPickHelper
================================

### 更新日志 Update log 2018.04.10

#### 服务器状态 Server status

* 部署网页应用成功 域名：http://heropick.win
* Deploy Web App succeeded Domain: http://heropick.win

# 简介 Introduction

* 这是一个网页应用项目
* This is a web application project

* 基于ASP.NET MVC5框架开发
* Based on ASP.NET MVC5 Framework

* 本应用的目的在于为Dota2玩家提供科学的、有针对性的己方英雄阵容
* This application is designed to provide scientifically counter hero pick suggestions for Dota2 player

* 使用但不限于以下技术:
* Utilizing but not limited to the following technique:

	- 前端 Front-end
  
		* HTML
		* CSS
		* JavaScript
		* C#(Razor)
		* jQuery
		* ajax
    
	- 后端 Back-end
  
		* C#
		* Entity Framework
		* .NET Web API
		* Microsoft SQL Server
		
	- 前端插件 Front-end Plug-in
	
		* DataTable.js
		* Layui.layer
		* 3d-hover.js

# 项目计划表 To Do List

* 通过自制Api获取英雄信息，添加英雄职责，写入数据库	![Demo](https://img.shields.io/badge/tests-1%2F1-brightgreen.svg)

* 获取英雄克制数据，写入数据库	![Demo](https://img.shields.io/jenkins/c/https/jenkins.qa.ubuntu.com/view/Utopic/view/All/job/address-book-service-utopic-i386-ci.svg)
	- 本项目无法通过官方公开Api计算英雄克制数据。原因为本项目使用自制Api导入英雄数据到数据库，
	英雄Id与官方英雄Id错位(可能官方有未公布的英雄占用了一个Id)。唯一获取英雄克制数据的途径只有爬
	虫脚本。

* 基于英雄克制数据，设计英雄推荐列表生成算法	![Demo](https://img.shields.io/badge/tests-115%2F115-brightgreen.svg)

* 搭建RESTful Api	![Demo](https://img.shields.io/badge/tests-2%2F2-brightgreen.svg)
	- 封装算法，直接向客户端返回英雄推荐列表粗数据(json格式)
	- 公开以下Api：
	
		* `heropick.win/api/herocolored`  GET请求，按头像颜色分类返回所有英雄列表
		* `heropick.win/api/hero`  GET请求，返回所有英雄职责列表
		* `heropick.win/api/herocalculator`  POST请求，发送英雄ID数组，返回选择方案

* 制作前端页面	![Demo](https://img.shields.io/coveralls/bitbucket/pyKLIP/pyklip.svg)
	- 调用 POST `~/api/herocalculator` 在客户端解析数据
 	- 生成可视化列表
	
# 使用 Usage

* 浏览器输入域名Domain：http://heropick.win

# 部署状态 Deployment status

* 已部署到阿里云服务器，服务器地理位置位于美国硅谷
* 操作系统: Window Server 2012 R2
* 配置: 1 vCPU 1 GB (I/O优化) ecs.xn4.small 30Mbps (峰值)
* 域名: heropick.win 租期一年
* 记录类型: A
* 主机记录: @
* TTL: 10 min

# 服务器环境配置状态 Server environment config status
* IIS8.5 已安装
* 尝试安装 MS SQL Server 2017 Express Edition 失败
* 尝试安装 MS SQL Server 2017 Developer Edition 失败
* 安装 MS SQL Server 2008 Express Edition 成功

# 当前样本 Current Demo
### 主功能页面框架MainFunctionPageFramework
![Demo](https://github.com/sdw283074970/HeroPickHelper/blob/master/pic/MainResultPage.png)

### 英雄选择效果HeroPickPage
![Demo](https://github.com/sdw283074970/HeroPickHelper/blob/master/pic/HeroPickPage.png)

### 示例Demo
![Demo](https://github.com/sdw283074970/HeroPickHelper/blob/master/pic/HeroPickHelperDemo.png)

# 联系方式 Contact

* Email: downwes@gmail.com
