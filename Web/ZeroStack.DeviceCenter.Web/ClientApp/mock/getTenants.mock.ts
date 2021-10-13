// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/Tenants': (req: Request, res: Response) => {
    res.status(200).send({
      items: [
        {
          id: 'FAdb0bC2-7559-DBbb-7Caf-1bAE89Cc928e',
          name: '陆勇',
          displayName: '前便去决格何名生活且老地合好其其然。',
          connectionString: '放改约己体把列过么务时商更矿具。',
          creationTime: '1990-09-02 05:43:05',
        },
        {
          id: '33eeBcFe-bBfC-fcFF-dA94-c5E3Dc5D9ADC',
          name: '黄杰',
          displayName: '治打受问王除层风识劳取联。',
          connectionString: '结反增重过技团高据叫流队光化。',
          creationTime: '1986-10-10 03:40:45',
        },
        {
          id: 'CEDc0Fce-E4dd-c116-beEd-F4737c1E6CbA',
          name: '邵强',
          displayName: '广酸电下都行被主活经明十相教口。',
          connectionString: '法自油非从光然金始支所子老空律系省度。',
          creationTime: '2001-07-28 09:21:57',
        },
        {
          id: 'cFD8DE1F-5281-7A64-BB71-E40A69cbbfC5',
          name: '蔡桂英',
          displayName: '用代完查那小率斗于还听月例金段来新。',
          connectionString: '精音义部飞整身点群转除然接正育。',
          creationTime: '1985-06-22 02:50:58',
        },
        {
          id: 'f72fBCF6-cCf2-DD2F-8c4E-7dBf7C2E54c8',
          name: '余秀兰',
          displayName: '特命反传说斯认石选养只质精委任里。',
          connectionString: '光收技价万这先海离低只统定支使。',
          creationTime: '2020-04-18 11:04:44',
        },
        {
          id: '686c7Cae-bce7-Be4e-2f1C-Edc91e8f6d3B',
          name: '杨明',
          displayName: '史给她月别使连之式金本图什你。',
          connectionString: '声正务得更华象装队学型你府。',
          creationTime: '1982-05-08 16:09:36',
        },
        {
          id: 'E198E335-F04f-B9C9-1928-ee46Cf6ECcAD',
          name: '丁静',
          displayName: '完领然化织间向验将并但点理。',
          connectionString: '打才往比拉气支求构很区通性。',
          creationTime: '2019-06-04 11:45:16',
        },
        {
          id: 'B81CCb19-b3Ff-205e-05bD-cE8bccc25F5f',
          name: '彭杰',
          displayName: '车无观打管并么铁没再机半。',
          connectionString: '眼领战信类身相适号她头十或非。',
          creationTime: '2007-02-27 12:59:05',
        },
      ],
      totalCount: 84,
    });
  },
};
