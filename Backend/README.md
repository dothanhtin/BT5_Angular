### RESTful API DMS (Sohoa)

[![Build Status](https://jenkins.vdc2.com.vn/buildStatus/icon?job=sohoa-backend%2Fdev&subject=dev)](https://jenkins.vdc2.com.vn/job/sohoa-backend/job/dev/)
[![Build Status](https://jenkins.vdc2.com.vn/buildStatus/icon?job=sohoa-backend%2Fmaster&subject=master)](https://jenkins.vdc2.com.vn/job/sohoa-backend/job/master/)
[![Build Status](https://jenkins.vdc2.com.vn/buildStatus/icon?job=sohoa-backend%2Fstaging&subject=staging)](https://jenkins.vdc2.com.vn/job/sohoa-backend/job/staging/)
[![Build Status](https://jenkins.vdc2.com.vn/buildStatus/icon?job=sohoa-backend%2Frelease&subject=release)](https://jenkins.vdc2.com.vn/job/sohoa-backend/job/release/)

## Description

- Mô hình giao tiếp:

(đang cập nhật)

- Thành viên: 
  - Hồ Chí Thanh -  thanhhc.it2@vnpt.vn (PM)
  - Đặng Duy Khang - khanddd@vnpt.vn (Developer)
  - Nguyễn Trọng Bình - trongbinh@vnpt.vn (Developer)
- Liên hệ: Email như trên
- Phương thức hỗ trợ: Get, Post, Put, Delete.
- Ngôn ngữ lập trình: C#
- Framework: Dot Net Core



## How to Use

Cài đặt (nếu chưa cài đặt):
	- Visual Studio (hoặc IDE tương tự có hồ trợ dot net core)
	- Dot net core 2.2.3
	- GhostScript
	- IIS

Khởi động chương trình:
	- Chọn DMS.RestApi là Startup project
	- Run project trên visual studio

Địa chỉ IP: localhost

Cổng kết nối: tùy máy mà port khác nhau (http://localhost:XXXX/)
(Check api: http://localhost:XXXX/api/menu/alllist )



## How to Publish server

https://docs.microsoft.com/en-us/visualstudio/deployment/quickstart-deploy-to-a-web-site?view=vs-2019



## How to Config

Cấu hình kết nối Database trong file

Chỉnh sửa các dòng thành data mong muốn

```
 "couchbase": {
    "hosts": "http://AA.BB.CC.DD:EEEE/",
    "username": "Administrator",
    "password": "123456"
  },
```



## How to Test

Công cụ để test: [Postman](https://www.getpostman.com/downloads/)

