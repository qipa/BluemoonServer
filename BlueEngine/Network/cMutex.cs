﻿//----------------------------------------------------------------------------------------------------
// cMutex
// : Mutex 객체
//   System.Threading.Mutex는 Unity WebPlayer에서 사용이 안되므로 자체 제작한다.
//  -JHL-2012-03-23
//----------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading;

namespace BlueEngine
{
	//----------------------------------------------------------------------------------------------------
	/// <summary>
	/// Mutex 객체
	/// </summary>
	//----------------------------------------------------------------------------------------------------
	public class cMutex
	{
		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 잠금 플래그
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private bool	m_lock;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 생성자
		/// </summary>
		/// <param name="initiallyOwned">호출한 스레드에 뮤텍스의 초기 소유권을 부여하면 true이고, 그렇지 않으면 false입니다.</param>
		//----------------------------------------------------------------------------------------------------
		public cMutex( bool initiallyOwned )
		{
			m_lock = !initiallyOwned;
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 잠금 해재될때까지 기다린다.
		/// </summary>
		/// <returns></returns>
		//----------------------------------------------------------------------------------------------------
		public bool WaitOne()
		{
			while( m_lock ) Thread.Sleep(0);
			lock(this) return m_lock = true;
		}

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// 잠금을 해제한다.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		public void ReleaseMutex()
		{
			lock(this) m_lock=false;
		}
	}
}
