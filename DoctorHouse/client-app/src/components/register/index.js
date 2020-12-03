import React,{Component} from 'react';

import { Form, Input, InputNumber, Button } from 'antd';

const layout = {
  labelCol: {
    span: 8,
  },
  wrapperCol: {
    span: 16,
  },
};
const validateMessages = {
  required: '${label} is required!',
  types: {
    email: '${label} is not a valid email!',
    number: '${label} is not a valid number!',
    password: '${label} is not a valid number!',
  },
  number: {
    range: '${label} must be between ${min} and ${max}',
  },
};


    
    
    class Register extends Component {
        
        render() { 
            const onFinish = (values) => {
                console.log(values);
              };
            
            return ( 
              

             <Form {...layout} name="nest-messages" onFinish={onFinish} validateMessages={validateMessages}>
      <Form.Item
        name={['user', 'name']}
        label="Name"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input />
      </Form.Item>
            
            <Form.Item
          label="Password"
          name={['user',"password"]}
          rules={[{ required: true, message: 'Please input your password!' }]}
        >
          <Input.Password />
        </Form.Item>
      <Form.Item
        name={['user', 'email']}
        label="Email"
        rules={[
          {
              type: 'email',
            },
        ]}
      >
        <Input />
        </Form.Item>
        <Form.Item
        name={['user', 'phone']}
        label="Phone"
        rules={[
          {
              type: 'phone',
            },
        ]}
      >
        <Input />
        </Form.Item>
      <Form.Item
        name={['user', 'age']}
        label="Age"
        rules={[
          {
            type: 'number',
            min: 16,
            max: 99,
            
          },
        ]}
      >
        <InputNumber />
      </Form.Item>
      <Form.Item name={['user', 'about']} label="About">
        <Input.TextArea />
      </Form.Item>
      <Form.Item wrapperCol={{ ...layout.wrapperCol, offset: 8 }}>
        <Button type="primary" htmlType="submit">
          Submit
        </Button>
      </Form.Item>
    </Form>
     );
    }}

export default Register;