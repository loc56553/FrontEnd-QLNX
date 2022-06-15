import axios from '../axios';

const userService = {
    // 
    handleLogin(userName, passWord) {
        return axios.post('/api/NhanVien/Login', {userName, passWord});
    }
}

export default userService;