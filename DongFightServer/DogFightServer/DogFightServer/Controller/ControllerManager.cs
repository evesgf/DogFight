﻿using Common;
using DogFightServer.Server;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DogFightServer.Controller
{
    class ControllerManager
    {
        private Dictionary<RequestCode, BaseController> controllerDict = new Dictionary<RequestCode, BaseController>();
        private ServerEntry server;

        public ControllerManager(ServerEntry server)
        {
            this.server = server;
            InitController();
        }

        void InitController()
        {
            DefaultController defaultController = new DefaultController();
            controllerDict.Add(defaultController.RequestCode, defaultController);
        }

        public void HandleRequest(RequestCode requestCode, ActionCode actionCode,string data,Client client)
        {
            BaseController controller;
            bool isGet=controllerDict.TryGetValue(requestCode, out controller);
            if (isGet == false)
            {
                Console.WriteLine("无法得到:" + requestCode + " 所对应的controller,无法处理请求");
                return;
            }
            string methodName=Enum.GetName(typeof(ActionCode),actionCode);
            MethodInfo mi = controller.GetType().GetMethod(methodName);
            if (mi == null)
            {
                Console.WriteLine("[警告]在controller:"+ controller.GetType() + " 中没有对应的处理方法:" + methodName);
                return;
            }
            object[] paramethers = new object[] { data, client,server };
            object o = mi.Invoke(controller, paramethers);
            if (o == null || string.IsNullOrEmpty(o as string))
            {
                return;
            }

            server.SendResponse(client, requestCode, o as string);
        }
    }
}
