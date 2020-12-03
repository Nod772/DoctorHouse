import logo from './logo.svg';
import 'antd/dist/antd.css';
import './App.css';
import React,{Component,Suspense} from 'react';
import {Route, Switch } from 'react-router-dom';
import { Layout, Menu, Breadcrumb } from 'antd';

//import {DatePicker} from 'antd';
const HomePage =React.lazy(()=>import ('./components/home'));
const Navbar =React.lazy(()=>import ('./components/navbar'));
const Register =React.lazy(()=>import ('./components/register'));
const Login =React.lazy(()=>import ('./components/login'));

const { Header, Content, Footer } = Layout;


class App extends Component {
 
  render() { 
    return  (
      <Suspense fallback={<p>Loading...</p>}>
          <Layout className="layout" style={{height: "100vh"}}>

        <Navbar/>
        <Content style={{ padding: '0 50px' }}>
          <Breadcrumb style={{ margin: '16px 0' }}>
             <Breadcrumb.Item>Home</Breadcrumb.Item>
             <Breadcrumb.Item>List</Breadcrumb.Item>
             <Breadcrumb.Item>App</Breadcrumb.Item>
          </Breadcrumb>
      <div className="site-layout-content">

        <Switch>
          <Route exact path='/' render={()=><HomePage/>}/>
        </Switch>
        <Switch>
          <Route exact path='/Register' render={()=><Register/>}/>
        </Switch>
        <Switch>
          <Route exact path='/Login' render={()=><Login/>}/>
        </Switch>

        </div>
          
        </Content>
        <Footer style={{ textAlign: 'center' }}></Footer>
        </Layout>
         </Suspense>
         );
  }
}
 




export default App;
