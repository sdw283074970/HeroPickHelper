英雄选择助手HeroPickHelper
====

### 简介Introduction

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
	 	* Angular(如果有人会这个最好，没人的话只能用RazorView)
    
	- 后端 Back-end
  
		* C#
		* Entity Framework
		* .NET Web API
		* Microsoft SQL Server

### 项目计划表 To Do List

* 通过Steam官方Api获取英雄信息，添加英雄职责，写入数据库	![Demo](https://img.shields.io/badge/tests-1%2F1-brightgreen.svg)

* 获取英雄克制数据，写入数据库	![Demo](https://img.shields.io/sonar/4.2/http/sonar.petalslink.com/org.ow2.petals%3Apetals-se-ase/coverage.svg)
	- 选择1：获得类似网站(如MAX+，或DotaBuff)Api授权，直接获取英雄克制数据
	- 选择2：使用你懂的抓取以上网站的英雄克制数据
	- 选择3：通过Steam暴露的Api获得近期比赛大数据，自己分析计算英雄克制数据

* 基于英雄克制数据，设计英雄推荐列表生成算法	![Demo](https://img.shields.io/sonar/4.2/http/sonar.petalslink.com/org.ow2.petals%3Apetals-se-ase/coverage.svg)

* 搭建RESTful Api	![Demo](https://img.shields.io/teamcity/coverage/bt428.svg)
	- 封装算法，直接向客户端返回英雄推荐列表粗数据(json格式)
	- 方法为POST，路由为 `~/api/herocalculator`

* 制作前端页面	![Demo](https://img.shields.io/coveralls/bitbucket/pyKLIP/pyklip.svg)
	- 调用 POST `~/api/herocalculator` 在客户端解析数据
 	- 生成可视化列表
	
### 安装 Installation

* 连接上本Github source直接克隆项目

### 部署 Deployment

* 部署方式待定

### 当前样本 Current Demo
![Demo](https://github.com/sdw283074970/HeroPickHelper/blob/master/pic/HeroPickHelperDemo.png)

### 联系方式 Contact

* Email: downwes@gmail.com
