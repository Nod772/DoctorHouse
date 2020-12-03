import React,{Component} from 'react';
import { Layout, Menu, Breadcrumb } from 'antd';
import { Link } from 'react-router-dom';
const { Header, Content, Footer } = Layout;

class Navbar extends Component {
    state = {  }
    render() { 
        return (
            <Header>
              <div className="logo" />
              <Menu theme="dark" mode="horizontal" defaultSelectedKeys={['2']}>
                <Menu.Item key="1"><Link to="/">Home Page</Link></Menu.Item>
                <Menu.Item key="2"><Link to="/register">Register</Link></Menu.Item>
                <Menu.Item key="3"><Link to="/login">Log In</Link></Menu.Item>
              
              </Menu>
            </Header>
           
          );
    }
}
 
export default Navbar;