%To plot filtered trajectory of trails 1-5 in one plot
x= s4t3S4(:,1);
y= s4t3S4(:,2);
z= s4t3S4(:,3);   %x is the data you import back from excel 
a= 1506;          %a and b are the limit of the selected signal
b= 1536;
c= 1508;
d= 1570;
e= 7408;
f= 7489;
g= 8493;
h= 8515;
i= 7038;
j= 7048;
xfs1= x(a:b);
yfs1= y(a:b);
zfs1 = z(a:b);

xfs2= x(c:d);
yfs2= y(c:d);
zfs2 = z(c:d);

xfs3= x(e:f);
yfs3= y(e:f);
zfs3= z(e:f);
 
xfs4= x(g:h);
yfs4= y(g:h);
zfs4= z(g:h);

xfs5= x(i:j);
yfs5= y(i:j);
zfs5= z(i:j);

%butterworth filter
SampleRate = 100;                     
FilterFrequency = 3; %Hz
Wn = FilterFrequency/(SampleRate/2);
[B, A] = butter(1,Wn,'low');
xfilt = filtfilt(B,A,xfs1);
yfilt = filtfilt(B,A,yfs1);
zfilt = filtfilt(B,A,zfs1);

FilterFrequency = 3; %Hz
Wn = FilterFrequency/(SampleRate/2);
[B, A] = butter(1,Wn,'low');
xfilt1 = filtfilt(B,A,xfs2);
yfilt1 = filtfilt(B,A,yfs2);
zfilt1 = filtfilt(B,A,zfs2);


FilterFrequency = 3; %Hz
Wn = FilterFrequency/(SampleRate/2);
[B, A] = butter(1,Wn,'low');
xfilt2 = filtfilt(B,A,xfs3);
yfilt2 = filtfilt(B,A,yfs3);
zfilt2 = filtfilt(B,A,zfs3);

FilterFrequency = 3; %Hz
Wn = FilterFrequency/(SampleRate/2);
[B, A] = butter(1,Wn,'low');
xfilt3 = filtfilt(B,A,xfs4);
yfilt3 = filtfilt(B,A,yfs4);
zfilt3 = filtfilt(B,A,zfs4);


FilterFrequency = 3; %Hz
Wn = FilterFrequency/(SampleRate/2);
[B, A] = butter(1,Wn,'low');
xfilt4 = filtfilt(B,A,xfs5);
yfilt4 = filtfilt(B,A,yfs5);
zfilt4 = filtfilt(B,A,zfs5);

close all
figure
%plot3(xaxis,yaxis,zaxis)
hold on;
%a = plot3(xfs1,yfs1,zfs1);
q=plot3(xfilt,yfilt,zfilt);
u= plot3(xfilt1,yfilt1,zfilt1);
e= plot3(xfilt2,yfilt2,zfilt2);
r= plot3(xfilt3,yfilt3,zfilt3);
t= plot3(xfilt4,yfilt4,zfilt4);
 legend([q,u,e,r,t],'i1','i2','i3','i4','i5')
title('fidget spinner s4t3')
xlabel('x(m)')
ylabel('y(m)')
hold off;

