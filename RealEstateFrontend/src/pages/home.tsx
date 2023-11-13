import Head from 'next/head';
import React, { useEffect, useState } from 'react';
import router from 'next/router';
import SidebarWithHeader from '../components/SideBar';
import HomeList from '../components/MainList/homeList';

const Home: React.FC = () => {
  const [token, setToken] = useState<string>('');

  useEffect(() => {
    const storageToken = localStorage.getItem('user');

    if (storageToken === null) {
      router.push('/login');
    }
    setToken(storageToken!);
  }, [token]);

  return (
    <SidebarWithHeader>
      <Head>
        <title>Home - Buscar imóvel</title>
      </Head>
      <HomeList />
    </SidebarWithHeader>
  );
};

export default Home;
